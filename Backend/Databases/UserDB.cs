using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Backend.Interfaces;
using Backend.csScripts;
using Backend.Modules;
namespace Backend.Databases;



public class UserDB : IUserDB
{
    static string dbName = "Account";
    static string cName = "Users";

    
    IMongoCollection<UserModule> collec;

    IUserAccount acc;

    ISubcriberDB subDB;

    IBlogDB blogDB;



    public UserDB(IMongoClient mongoClient,IMongoDBConnection<UserModule> _dbConnect,IUserAccount _acc,ISubcriberDB _subDB, IBlogDB _blogDB)
    {

        collec = _dbConnect.ReturnCollection(mongoClient,dbName,cName);

        acc = _acc;
        subDB = _subDB;
        blogDB = _blogDB;
    }
   
    public async Task<IActionResult> CreateAccount(UserModule user)
    {
        try{
            if(user.Email != string.Empty &&
               user.Password != string.Empty &&
               user.FirstName != string.Empty &&
               user.LastName != string.Empty 
            )
            {
                var userExist = await collec.Find(x => user.Email == x.Email).FirstOrDefaultAsync<UserModule>(); 
                if (userExist is null){

                //if user doesn't exist hash password then create account
                user.Password = acc.HashPassword(user.Password.ToString());
                await collec.InsertOneAsync(user);
                
                //After user is created AutoFollow
                var createdUser = await collec.Find(x => x.UserId == user.UserId).FirstOrDefaultAsync<UserModule>();
                var otherUsers = await collec.FindAsync(x => x.UserId != user.UserId);
                if(otherUsers != null){
                foreach(var _oUser in otherUsers.ToList()){
                   await subDB.Follow(createdUser.UserId,_oUser.UserId);
                    }
                }
               
                //Give AuthToken

                return new OkObjectResult(acc.GenerateJwtToken(user));
                }else{
                    return new UnauthorizedObjectResult("Email exist already!");
                }
            {
        }
            }else{
                return new NoContentResult();
            }
        }catch(Exception e){

            //Log 
            return new UnauthorizedObjectResult(e);
        }
    }
    public async Task<IActionResult> LogIn(UserModule user)
    {
        try {
        if(user.Password != string.Empty && user.Email != string.Empty)
        {
            var userExist = await collec.Find(x => user.Email == x.Email).FirstOrDefaultAsync<UserModule>();

            if(userExist is null){
                 return new UnauthorizedObjectResult("Email does't exist");
            }
            if(!acc.PasswordAuthentication(user.Password, userExist.Password)){
                 return new UnauthorizedObjectResult("Credidentials invalid");
             }else{
                  return new OkObjectResult(acc.GenerateJwtToken(userExist));
             }
        }else
        {
        return new UnauthorizedObjectResult("Invalid Credidentials");
        }

        }catch(Exception e){

            //Log

            return new UnauthorizedObjectResult(e.Message);
        }
    }


    //Last feature to do.
      //User Follow User
    public async Task<Object[]> Profile(string userId){

        List<UserModule> subcribed = new List<UserModule>();
        List<BlogModule> blogs = new List<BlogModule>();
     
            try{
                //Get user subcribed then get blogs
                List<SubcriberModule> tempSub   = await subDB.GetSubcribed(userId);
            

                if(tempSub != null){
                     foreach(var _user in tempSub){
                     List<BlogModule> tempBlog = await blogDB.GetBlogs(_user.Subcribed);
                    var u = await collec.Find(x => x.UserId == _user.Subcribed).FirstOrDefaultAsync();
                   
                    subcribed.Add(new UserModule(){
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserId = u.UserId
                    });
                        if(tempBlog != null){
                            foreach(var blog in tempBlog){
                                blogs.Add(blog);
                            }
                        }
                    //Now check if main user has any post

                      
                    }
                      List<BlogModule> userBlogs = await blogDB.GetBlogs(userId);
                    var myUser = await collec.Find(x => x.UserId == userId).FirstOrDefaultAsync();
                        if(userBlogs != null){
                             foreach(var blog in userBlogs){
                                blogs.Add(blog);
                            }
                        }
                     object[] result =  {subcribed,blogs,new UserModule(){
                        FirstName = myUser.FirstName,
                        LastName = myUser.LastName,
                        UserId = myUser.UserId
                     }};
                     return result;
                }else{
                    return null;
                }
               
            
            
            }catch(Exception e){

                return null;
            }

    }

}