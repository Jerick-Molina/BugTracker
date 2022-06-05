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
[Route("OAuth")]
public class OAuthController 
{
    [HttpGet("")]
    public async Task<IActionResult> CreateAccount(){

        return new OkObjectResult("CreateAccount"); 
    }
    [HttpGet("")]
    public async Task<IActionResult> SignIn(){

        return new OkObjectResult("SignIn"); 
    }
}