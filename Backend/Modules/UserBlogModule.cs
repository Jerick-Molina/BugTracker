using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class UserBlogModule {
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}
    
    public List<BlogPostModule> BlogPost {get;set;}

    public List<UserBlogModule> UserFollowing {get;set;}

    public List<BlogPostModule> UserLikedPost {get;set;}



}