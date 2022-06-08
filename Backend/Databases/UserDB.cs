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
    static string dbName = "TestDB";
    static string cName = "Users";

    
    IMongoCollection<UserModule> collec;

    IUserAccount acc;

    public UserDB(IMongoDBConnection<UserModule> _dbConnect, IUserAccount _acc)
    {

        collec = _dbConnect.ReturnCollection("TestDB","Users");

        acc = _acc;
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

                //Give AuthToken

                return new OkObjectResult("Account Created");
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
                  return new OkObjectResult("Signed in!");
             }
        }else
        {
        return new UnauthorizedObjectResult("Invalid Credidentials");
        }

        }catch(Exception e){

            //Log

            return new UnauthorizedObjectResult(e);
        }
    }
}