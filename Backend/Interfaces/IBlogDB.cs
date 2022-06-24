
using System.Security.Claims;
using Backend.Modules;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;

namespace Backend.Interfaces;

public interface IBlogDB {

  Task<List<BlogModule>> GetBlogs(string userID);
  Task<IActionResult> ReadBlog(string blogId);
  Task<IActionResult> PostBlog(ClaimsIdentity user,
    BlogModule user_blog);
  
  Task<IActionResult> EditBlog(ClaimsIdentity user,BlogModule blog);

  Task<IActionResult> DeleteBlog(ClaimsIdentity user,string blogId);

}