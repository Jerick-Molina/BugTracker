using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class BlogPostModule {
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id {get;set;}
    public string Author {get;set;}
    public String Title {get;set;}
    public String BlogPost {get;set;}
    public int ThumbsUp {get;set;}

}