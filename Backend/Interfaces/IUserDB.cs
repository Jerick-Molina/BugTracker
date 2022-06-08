

using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
using Backend.Interfaces;
using Backend.Modules;
public interface IUserDB 
{

    Task<IActionResult> CreateAccount(UserModule user);
    Task<IActionResult> LogIn(UserModule user);
}