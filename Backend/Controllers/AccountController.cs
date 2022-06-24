    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System.Net.Http;
    using Newtonsoft.Json;
    using MongoDB;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using Backend.Modules;
    using Backend.Databases;
    using Backend.csScripts;
    using Backend.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    namespace Backend.Controllers;


    [ApiController]
    [Route("Account")]
    [Produces("application/json")]
    public class AccountController 
    {
    
        private IUserDB userDB;
        private IUserAccount userAcc;
        private IBlogDB blogDB;

        public AccountController(IUserDB _db,IUserAccount _userAcc,ISubcriberDB _subDB,IBlogDB _blogDB){
            userDB = _db;
            userAcc = _userAcc;
            blogDB = _blogDB;
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(UserModule user){

            var results = await userDB.CreateAccount(user);
            return new OkObjectResult(results);
        }
        
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]UserModule user){

            var results = await userDB.LogIn(user);
            return new OkObjectResult(results);
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetProfile([FromHeader]string userId){

            
           
            if(userId == string.Empty)
            {
                var results = blogDB.GetBlogs(userId);
                return new OkObjectResult(results);
            }else{
           

            

            var results = await  userDB.Profile(userId);
            return new OkObjectResult(results);
            }
        }

        [HttpGet("Info")]
        [Authorize]
        public async Task<IActionResult> Info([FromHeader]string Authorization,[FromHeader]string userId){
           
            if(userId != "empty"){
                var user = await userDB.Profile(userId);
                return new OkObjectResult(user);
                     }else{

                string[] split = Authorization.Split(' ');
                 var user =   userAcc.ReadJwtToken(split[1].ToString());
                return new OkObjectResult(user);
            }
           
            
            
        }

        [HttpGet("Home")]
        [Authorize]
        public async Task<ActionResult<string>> GetHome([FromHeader]string Authorization){

            
            string[] split = Authorization.Split(' ');

            var user =   userAcc.ReadJwtToken(split[1].ToString());

            var results =  await userDB.Profile(user.UserId);

            // if(results ==null){
            //     return new NotFoundResult();
            // }

            return new OkObjectResult(results);
        }


    }