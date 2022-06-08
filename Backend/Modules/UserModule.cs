using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Backend.Modules;



public class UserModule
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("UserId")]
    public string? UserId {get;set;} 

   
    public string Email {get;set;} = string.Empty;

    public string Password {get;set;} = string.Empty;


     public string FirstName {get;set;} = string.Empty;

  
    public string LastName  {get;set;} = string.Empty;
}