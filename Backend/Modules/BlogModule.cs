using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Modules;


public class BlogModule 
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string BlogId {get;set;} = string.Empty;
    //Uses UserID
   
    public string AuthorId{get;set;} = string.Empty;
       
    public DateTime Date {get;set;}
    public string Title {get;set;} = string.Empty;
    public string Body {get;set;} = string.Empty;
    public int ThumbsUp {get;set;}

}