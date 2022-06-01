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

    public MongoDBConnection(string _cNameString, string _dbString)
    {
        cNameString = _cNameString;
        dbString = _dbString;

        client = new MongoClient(connectionString);
        db = client.GetDatabase(dbString);
        collection = db.GetCollection<T>(cNameString);
    }


    // Get All Query
    public async Task<IActionResult> GetAllResults()
    {
        var r = await collection.FindAsync(_ => true);
        return new OkObjectResult(r.ToList());
    }


    // public async Task<IActionResult> GetResults()
    // {

    //     var r = await collection.FindAsync(_ => true);  
    //     return new OkObjectResult(r.ToList());
    // }






}