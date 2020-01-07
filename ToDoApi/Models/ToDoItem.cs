using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
  public class ToDoItem
  {
    public long ToDoItemId { get; set; }
    public string ToDoItemName { get; set; }
    public bool IsComplete { get; set; }

    public ToDoItem()
    {
      IsComplete = false; 
    }

  }
}
