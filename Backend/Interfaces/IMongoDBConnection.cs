
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
namespace Backend.Interfaces;

public interface IMongoDBConnection<T> {
   

  public IMongoCollection<T> ReturnCollection(IMongoClient client,string dbName,string cName);
   
}