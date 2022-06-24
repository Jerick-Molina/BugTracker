using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Backend.Modules;


public class SubcriberModule {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id {get;set;}
    
    //From
    public string? Subcriber {get;set;}

    public string? Subcribed {get;set;}
    //To

}