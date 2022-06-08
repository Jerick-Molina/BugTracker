using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Backend.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Backend.csScripts;
using Backend.Modules;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.csScripts;


public class UserAccount : IUserAccount
{
    public string GenerateJwtToken(UserModule user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("4zljz0npg5c9bmm5"));
        var credidentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim("UserId", user.UserId),
            new Claim("UserPass",user.Password),
            new Claim("FirstName", user.FirstName),
            new Claim("LastName",user.Password)
            };
        var token = new SecurityTokenDescriptor{
            Issuer = "https://localhost:7235",
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = credidentials
        };

        var t = tokenHandler.CreateToken(token);

        
        return tokenHandler.WriteToken(t);
    }

 
    //Hash
    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] value;
            UTF8Encoding encoder = new UTF8Encoding();

            value = sha256.ComputeHash(encoder.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {

                builder.Append(value[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    //Loging
    public bool PasswordAuthentication(string password, string hashed)
    {

        var hash = HashPassword(password);

        if (hash == hashed)
        {
            return true;
        }
        return false;
    }

}