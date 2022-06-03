using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Backend.Modules;
using Backend.csScripts;
namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MongoDBController : ControllerBase
{
      
    

        string connectionString = "";
        string db = "TestDB";
        string cName = "user";

    [HttpGet("AddThingy")]
    public async Task<IActionResult> Add()
    {

    var test = new  UserModule();
        test.FirstName = "Mike";
       test.LastName = "Johnson";
      
        string connectionString = "mongodb://AdminJerick:Mixon9090!@192.168.3.139:27017/?authSource=admin";
            string db = "TestDB";
            string cName = "user";

            var client = new MongoClient(connectionString);
            var ddb = client.GetDatabase(db);
            var collec = ddb.GetCollection<UserModule>(cName);

            await collec.InsertOneAsync(test);

        return new OkObjectResult("Success");  
    }




    [HttpGet()]
    public async Task<IActionResult> Get()
    {
          
            return new OkObjectResult("Test"); 
    }
    
}
