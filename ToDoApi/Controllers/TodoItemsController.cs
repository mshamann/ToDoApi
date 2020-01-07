using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ToDoApi.Models;
using ToDoApi.Repositories.interfaces;

namespace ToDoApi.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class TodoItemsController : Controller
  {

    private readonly IToDoItemRepository _toDoItemRepo;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TodoItemsController> _logger;

    public TodoItemsController(ILogger<TodoItemsController> logger,IToDoItemRepository toDoRepo,IConfiguration configuration,IToDoItemRepository toDoItemRepo)
    {
      _logger = logger;
      _toDoItemRepo = toDoItemRepo;
      _configuration = configuration;
    }

    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
      }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetItemList()
    {
      using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
      connection.Open();

      if (connection.QueryFirstOrDefault<int?>(@"SELECT id 
                                                FROM todoitem i 
                                                WHERE name = @name", new { Name = "Clean Basement" }) == null)
      {
        connection.Execute(@"INSERT TodoItem (Name) VALUES (@Name)",
                                     new ToDoItem
                                     {
                                       Name = "Clean Basement",
                                     });
      }

      return await _toDoItemRepo.GetItemList();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ToDoItem>> GetByID(int id)
    {
      return await _toDoItemRepo.GetById(id);
    }


  } 
}