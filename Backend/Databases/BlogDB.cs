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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Databases;



//NOTE CRUD OPERATIONS  besides *READ* needs authentication
public class BlogDB :  IBlogDB
{

     string dbName = "TestDB";
     string cName = "Blogs";

    BlogModule blog = new BlogModule();
    IMongoCollection<BlogModule> collec;

    IUserAccount acc;
    public BlogDB(IMongoDBConnection<BlogModule> _dbConnect, IUserAccount _acc){


      collec = _dbConnect.ReturnCollection(dbName,cName);
       
      acc = _acc;
    }

    public async Task<IActionResult> PostBlog(ClaimsIdentity user,
    BlogModule user_blog)
    {
         try{
           if(user.Claims.First(c => c.Type == "UserId").Value != null)
           {
             blog.AuthorId = user.Claims.First(c => c.Type == "UserId").Value;
             blog.Title = user_blog.Title;
             blog.Body = user_blog.Body;
             blog.Date = user_blog.Date;

             await collec.InsertOneAsync(blog);
              return new OkObjectResult("Document Inserted");
           }else{
              return new UnauthorizedObjectResult("UserIdNotValid");
           }
         }catch(Exception e)
         {
         return new OkObjectResult(e);
         }
      
    }
 //post_blogs
   public async Task<IActionResult> ReadBlog(BlogModule blog)
    {
           try{
              var rBlog = await collec.Find(b => b.BlogId == blog.BlogId).FirstOrDefaultAsync<BlogModule>();

               if(rBlog is null){
                     return new UnauthorizedObjectResult("UnKnown blog");
               }
              return new OkObjectResult(rBlog);
        
         }catch(Exception e)
         {
         return new OkObjectResult(e.Message);
         }
    }
    //post_blogs
    //This will be finished once its UI compatable
    public async Task<IActionResult> EditBlog(ClaimsIdentity user,BlogModule blog)
    {
         
       try{
           if(user.Claims.First(c => c.Type == "UserId").Value != null)
           {
             
           

            
              return new OkObjectResult("Document Inserted");
           }else{
              return new UnauthorizedObjectResult("UserIdNotValid");
           }
       }catch(Exception e){
            return new OkObjectResult(e.Message);
       }
        var r = await collec.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }

    //Delete Blogs
    public async Task<IActionResult> DeleteBlog(ClaimsIdentity user,BlogModule blog)
    { 
       
       try{
         if(user.Claims.First(c => c.Type == "UserId").Value != null)
           {
             var userId = user.Claims.First(c => c.Type == "UserId").Value;
             await collec.DeleteOneAsync(x => x.BlogId == blog.BlogId && x.AuthorId == userId);

            
              return new OkObjectResult("Document Deleted");
           }else{
              return new UnauthorizedObjectResult("UserIdNotValid");
           }
       }catch(Exception e){
            return new OkObjectResult(e.Message);
       }
            var r = await collec.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }

  

}