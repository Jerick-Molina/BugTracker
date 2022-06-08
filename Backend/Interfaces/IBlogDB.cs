
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
namespace Backend.Interfaces;

public interface IBlogDB {
  Task<IActionResult> PostBlog(string user_id,
 string post_id,string post_header,string post_body,DateTime date);
  
  Task<IActionResult> EditBlog(string user_id,string post_id);

  Task<IActionResult> DeleteBlog(string user_id,string post_id);

  Task<IActionResult> Follow(string user_id_one,string user_id_two);
  
  Task<IActionResult> UnFollow(string user_id_one,string user_id_two);
}