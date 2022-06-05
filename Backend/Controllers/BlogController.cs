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
[Route("Blog")]
public class BlogController : ControllerBase
{
      

        string connectionString = "";
        string db = "TestDB";
        string cName = "user";

   

    [HttpPost("Add")]
    public async Task<IActionResult> blogs_add(){

        return new OkObjectResult("add"); 
    }
    [HttpGet("Delete")]
    public async Task<IActionResult> blogs_delete(){

        return new OkObjectResult("delete"); 
    }
    [HttpPost("Edit")]
    public async Task<IActionResult> blogs_edit(){

        return new OkObjectResult("edit"); 
    }

    [HttpGet("Home")]
    public async Task<IActionResult> Home()
    {
          
            return new OkObjectResult("Test"); 
    }
    
}
