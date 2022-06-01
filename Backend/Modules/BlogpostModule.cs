using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class BlogPostModule {
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}
    public string Author {get;set;} 
    public string Title {get;set;} 
    public DateTime DatePosted {get;set;}
    public string BlogPost {get;set;} 
    public int ThumbsUp {get;set;}

}