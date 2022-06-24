using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
using Backend.Modules;
namespace Backend.Interfaces;

public interface IUserAccount
{
    string GenerateJwtToken(UserModule user);
    string HashPassword(string password);
    bool PasswordAuthentication(string password, string hashed);

    UserModule ReadJwtToken(string _token);
}
