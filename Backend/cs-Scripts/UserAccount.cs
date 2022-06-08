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

namespace Backend.csScripts;


public class UserAccount : IUserAccount
{


    public bool IsEmpty(UserModule user){


        

        return false;
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