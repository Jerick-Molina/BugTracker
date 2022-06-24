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

    public string? UserColor {get;set;} 
   
    public string?  AboutMe {get;set;} 
    
    public string?  Email {get;set;}

    public string?  Password {get;set;} 


     public string?  FirstName {get;set;}

  
    public string?  LastName  {get;set;}
}