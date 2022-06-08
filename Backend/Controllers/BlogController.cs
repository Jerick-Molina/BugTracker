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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Interfaces;
namespace Backend.Controllers;

[ApiController]
[Route("Blog")]
[Authorize]
public class BlogController : ControllerBase
{
      

     private IBlogDB db;

    public BlogController(IBlogDB _db){
        db = _db;
    }
   
     [HttpGet("Read")]
    [AllowAnonymous]
    public async Task<IActionResult> blogs_read([FromBody]BlogModule blog){

        if(blog.BlogId is null){
            return new UnauthorizedObjectResult("Nill");
        }
       var r = await db.ReadBlog(blog);
        return new OkObjectResult(r); 
    }
    [HttpPost("Add")]

    public async Task<IActionResult> blogs_add([FromBody]BlogModule blog){

        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if(identity is null){
            return new UnauthorizedObjectResult("UnAuthorized");
        }

        await db.PostBlog(identity,blog);
        return new OkObjectResult("added a post"); 
    }
    [HttpPost("Delete")]

    public async Task<IActionResult> blogs_delete([FromBody]BlogModule blog){
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if(identity is null){
            return new UnauthorizedObjectResult("UnAuthorized");
        }
        await db.DeleteBlog(identity,blog);
        
        return new OkObjectResult("deleted post"); 
    }
    [HttpPost("Edit")]

    public async Task<IActionResult> blogs_edit(){

        return new OkObjectResult("edit"); 
    }

    [HttpGet("Home")]
    [Authorize]
    public async Task<IActionResult> Home()
    {
          
            return new OkObjectResult("Test"); 
    }
    
}
