
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
namespace Backend.Interfaces;

public interface IMongoDBConnection {
  Task<IActionResult> PostBlogs(string user_id,
 string post_id,string post_header,string post_body,DateTime date);
  
  Task<IActionResult> EditBlogs(string user_id,string post_id);

  Task<IActionResult> DeleteBlogs(string user_id,string post_id);

  Task<IActionResult> Follow(string user_id_one,string user_id_two);
  
  Task<IActionResult> UnFollow(string user_id_one,string user_id_two);
}