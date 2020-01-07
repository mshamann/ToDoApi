using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToDoApi.Repositories.interfaces;
using ToDoApi.Models;
using Dapper;

namespace ToDoApi.Repositories
{
  public class ToDoItemRepository : IToDoItemRepository 
  {
    private readonly IConfiguration _configuration; 

    public ToDoItemRepository(IConfiguration configuration)
    {
      _configuration = configuration; 
    }

    public IDbConnection Connection
    {
      get
      {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
      }
    }

    public async Task<ToDoItem>  GetById(int id)
    {
      using IDbConnection conn = Connection;
      string Query = "SELECT ID, Name, IsComplete FROM ToDoItem WHERE ID = @ID";
      conn.Open();
      var result = await conn.QueryAsync<ToDoItem>(Query, new { ID = id });
      return result.FirstOrDefault();
    }

    public async Task<List<ToDoItem>> GetItemList()
    {
      using IDbConnection conn = Connection;
      string Query = "SELECT ID, Name, IsComplete FROM ToDoItem";
      conn.Open();
      var result = await conn.QueryAsync<ToDoItem>(Query);
      return result.ToList();
    }



  }
}
