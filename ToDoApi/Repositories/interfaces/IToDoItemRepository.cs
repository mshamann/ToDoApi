using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models; 

namespace ToDoApi.Repositories.interfaces
{
  public interface IToDoItemRepository
  {
    Task<ToDoItem> GetById(int id);
    Task<List<ToDoItem>> GetItemList(); 
  }
}
