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

public  class MongoDBConnection<T> : IMongoDBConnection<T>
{
    private IMongoClient client;
    private IMongoDatabase db;
    public IMongoCollection<T> collection;
    string connectionString = "mongodb://AdminJerick:Mixon9090!@192.168.3.139:27017/?authSource=admin";
  
   

    public  IMongoCollection<T> ReturnCollection(string dbName,string cName)
    {
        client =  new MongoClient(connectionString);
        db = client.GetDatabase(dbName);
        db.GetCollection<T>(cName);
        return  db.GetCollection<T>(cName);
    }

}

