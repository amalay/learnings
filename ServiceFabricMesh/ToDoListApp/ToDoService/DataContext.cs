using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace ToDoService
{
    public class DataContext
    {
        public static Entities.ToDoList ToDoList { get; } = new Entities.ToDoList("Azure learning List");

        static DataContext()
        {
            // Seed to-do list
            ToDoList.Add(Entities.ToDoItem.Load("Learn about microservices", 0, true));

            ToDoList.Add(Entities.ToDoItem.Load("Learn about Service Fabric", 1, true));

            ToDoList.Add(Entities.ToDoItem.Load("Learn about Service Fabric Mesh", 2, false));
        }
    }
}
