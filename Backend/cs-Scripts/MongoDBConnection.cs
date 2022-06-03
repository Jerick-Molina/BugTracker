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
namespace Backend.csScripts;



public class MongoDBConnection<T> :  IMongoDBConnection
{

    private string cNameString;
    private string dbString;

    private IMongoClient client;
    public IMongoDatabase db;

    public IMongoCollection<T> collection;
    private string connectionString = "";

    public MongoDBConnection( string _dbString,string _cNameString)
    {
        cNameString = _cNameString;
        dbString = _dbString;
        
        client = new MongoClient(connectionString);
        db = client.GetDatabase(dbString);
        collection = db.GetCollection<T>(cNameString);
    }

    //post_blogs
    public async Task<IActionResult> PostBlogs(string user_id,
    string post_id,string post_header,string post_body,DateTime date)
    {
        var r = await collection.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }
 //post_blogs
    public async Task<IActionResult> EditBlogs(string user_id,string post_id)
    {
        var r = await collection.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }

    //Delete Blogs
    public async Task<IActionResult> DeleteBlogs(string user_id,string post_id)
    {
            var r = await collection.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }

    //User Follow User
    public async Task<IActionResult> Follow(string user_id_one,string user_id_two)
    {
         var r = await collection.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }
    
    //User Unfollow User
   public async Task<IActionResult> UnFollow(string user_id_one,string user_id_two)
    {
         var r = await collection.FindAsync(_ => true);
            return new OkObjectResult(r.ToList());
    }

}