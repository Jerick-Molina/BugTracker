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



public class SubcriberDB : ISubcriberDB
{
    static string dbName = "Subcribers";
    static string cName = "Subcribed";


    IMongoCollection<SubcriberModule> collec;

    IUserAccount acc;
  

   
    public SubcriberDB(IMongoClient mongoClient,IMongoDBConnection<SubcriberModule> _dbConnect, IUserAccount _acc)
    {

        collec = _dbConnect.ReturnCollection(mongoClient,dbName, cName);

        acc = _acc;
        
    }

    public async Task<List<SubcriberModule>> GetSubcribed(string _userId)
    {

        try{
         var subcribed = await collec.Find(x => x.Subcriber == _userId).ToListAsync();
            if(subcribed == null){
                return null;
            }
         return subcribed;
         
        }catch(Exception e ){

         return null;
        }
     
    }
    //Last feature to do.


   
    //User Follow User
    public async Task<IActionResult> Follow(string user_id_one, string user_id_two)
    {   
        try{
         SubcriberModule subcribed = new SubcriberModule();
        subcribed.Subcriber = user_id_one;
        subcribed.Subcribed = user_id_two;
        await collec.InsertOneAsync(subcribed);
        }catch(Exception e)
        {
            return new UnauthorizedObjectResult(e.Data);
        }
       

        return new OkObjectResult("Subcribed");
    }

    //User Unfollow User
    public async Task<IActionResult> UnFollow(string user_id_one, string user_id_two)
    {
        var r = await collec.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }
}