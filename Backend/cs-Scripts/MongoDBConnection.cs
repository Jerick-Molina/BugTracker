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

    private IMongoDatabase db;
    public IMongoCollection<T> collection;

    

    public IMongoCollection<T> ReturnCollection(IMongoClient client,string dbName,string cName)
    {
       
        db = client.GetDatabase(dbName);
        db.GetCollection<T>(cName);
        return  db.GetCollection<T>(cName);
    }

}

