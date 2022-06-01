
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces;

public interface IMongoDBConnection {
  Task<IActionResult> GetAllResults();

  
}