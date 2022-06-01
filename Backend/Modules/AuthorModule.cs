using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class AuthorModule {
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id {get;set;}
    public string Author {get;set;}
    public string Title {get;set;}
    public string BlogPost {get;set;}
    public int ThumbsUp {get;set;}

}