using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Modules;


public class BlogModule 
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string BlogId {get;set;}
    //Uses UserID
   
    public string?  AuthorId{get;set;} 
       
    public DateTime Date {get;set;}
    public string?  Title {get;set;} 

    public string?  SubTitle {get;set;}
    public string?  Body {get;set;} 
    public int Hearts {get;set;}

}