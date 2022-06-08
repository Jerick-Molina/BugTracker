

using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
using Backend.Interfaces;
using Backend.Modules;
public interface IUserDB 
{

    Task<IActionResult> CreateAccount(UserModule user);
    Task<IActionResult> LogIn(UserModule user);

    Task<IActionResult> Follow(string user_id_one,string user_id_two);
    Task<IActionResult> UnFollow(string user_id_one,string user_id_two);
}