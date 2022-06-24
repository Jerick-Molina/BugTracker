using Backend.Modules;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
namespace Backend.Interfaces;


public interface ISubcriberDB
{
    Task<List<SubcriberModule>> GetSubcribed(string _userId);
    Task<IActionResult> Follow(string user_id_one, string user_id_two);
   
    Task<IActionResult> UnFollow(string user_id_one, string user_id_two);
}