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

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MongoDBController : ControllerBase
{
       public class Users{

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string _id {get;set;}
            public string blogs {get;set;}
        }

    
    

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
          string connectionString = "";
            string db = "Users";
            string cName = "user";

            var client = new MongoClient(connectionString);
            var ddb = client.GetDatabase(db);
            var collec = ddb.GetCollection<Users>(cName);

            var t = new Users();
             var r = await collec.FindAsync(_ => true);


            return new OkObjectResult(r.ToList());
    }
}
