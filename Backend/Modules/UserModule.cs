using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;



public class UserModule
{ 

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId {get;set;}

    public string Email {get;set;}
    
    public string Password {get;set;}
    
    public string FirstName {get;set;} 

    public string LastName  {get;set;}



}