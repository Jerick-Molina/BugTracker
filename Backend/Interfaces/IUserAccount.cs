using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
namespace Backend.Interfaces;

public interface IUserAccount
{
    string HashPassword(string password);
    bool PasswordAuthentication(string password, string hashed);
}
