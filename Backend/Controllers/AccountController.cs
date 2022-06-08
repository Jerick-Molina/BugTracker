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
using Backend.Databases;
using Backend.csScripts;
using Backend.Interfaces;
namespace Backend.Controllers;


[ApiController]
[Route("Account")]
[Produces("application/json")]
public class AccountController 
{

    private IUserDB db;

    public AccountController(IUserDB _db){
        db = _db;
    }

    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAccount(UserModule user){
       
       var results = await db.CreateAccount(user);
        return new OkObjectResult(results);
    }
    
    [HttpPost("SignIn")]
    public async Task<IActionResult> LogIn([FromBody]UserModule user){


        var results = await db.LogIn(user);

        return new OkObjectResult(results);
    }
    
}