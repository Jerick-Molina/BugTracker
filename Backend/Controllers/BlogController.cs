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
    public async Task<IActionResult> blogs_read([FromHeader] string blogId){

        if(blogId is null){
            return new UnauthorizedObjectResult("Nill");
        }
       var r = await db.ReadBlog(blogId);
        return new OkObjectResult(r); 
    }
    [HttpPost("Add")]
     [Authorize]
    public async Task<IActionResult> blogs_add([FromBody]BlogModule blog){

        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if(identity is null){
            return new UnauthorizedObjectResult("UnAuthorized");
        }

        var r = await db.PostBlog(identity,blog);
        return new OkObjectResult(r); 
    }
    [HttpPost("Delete")]
    [Authorize]
    public async Task<IActionResult> blogs_delete([FromHeader]string blogId){
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if(identity is null){
            return new UnauthorizedObjectResult("UnAuthorized");
        }
        
       var r = await db.DeleteBlog(identity,blogId);
        
        return new OkObjectResult(r); 
    }
    [HttpPost("Edit")]
    [Authorize]
    public async Task<IActionResult> blogs_edit([FromBody]BlogModule blog){
        
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if(identity is null){
            return new UnauthorizedObjectResult("UnAuthorized");
        }
        var r = await  db.EditBlog(identity,blog);
        return new OkObjectResult(r); 
    }

}
