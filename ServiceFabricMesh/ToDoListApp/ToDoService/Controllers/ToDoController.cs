using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET api/todo
        [HttpGet]
        public IEnumerable<Entities.ToDoItem> Get()
        {
            return DataContext.ToDoList.Items;
        }

        // GET api/todo/5
        [HttpGet("{index}")]
        public Entities.ToDoItem Get(int index)
        {
            return DataContext.ToDoList.Items.ElementAt(index);
        }

        // DELETE api/values/5
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
        }
    }
}