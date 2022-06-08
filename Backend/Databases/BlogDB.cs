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



public class BlogDB :  IBlogDB
{

     string dbName = "TestDB";
     string cName = "Users";

    IMongoCollection<BlogModule> db;
   
    public BlogDB(IMongoDBConnection<BlogModule> _db){
       // db = _db.ReturnCollection(dbName,cName);
       
    }
    
    //post_blogs
    public async Task<IActionResult> PostBlog(string user_id,
    string post_id,string post_header,string post_body,DateTime date)
    {
        var r = await db.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }
 //post_blogs
    public async Task<IActionResult> EditBlog(string user_id,string post_id)
    {
        var r = await db.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }

    //Delete Blogs
    public async Task<IActionResult> DeleteBlog(string user_id,string post_id)
    {
            var r = await db.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }

    //User Follow User
    public async Task<IActionResult> Follow(string user_id_one,string user_id_two)
    {
         var r = await db.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }
    
    //User Unfollow User
   public async Task<IActionResult> UnFollow(string user_id_one,string user_id_two)
    {
         var r = await db.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }

}