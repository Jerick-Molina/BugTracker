using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class UserBlogModule {
    
 [BsonId]
 [BsonRepresentation(BsonType.ObjectId)]
    public int Id {get;set;}
    
    public String User;
    public List<BlogPostModule> BlogPost {get;set;}

    public List<UserBlogModule> UserFollowing {get;set;}

    public List<BlogPostModule> UserLikedPost {get;set;}



}