using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ToDoController : Controller
    {
        private static string backendDNSName = $"{Environment.GetEnvironmentVariable("ToDoServiceName")}";
        private static Uri backendUrl = new Uri($"http://{backendDNSName}:{Environment.GetEnvironmentVariable("ApiHostPort")}/api/todo");

        public IActionResult Index()
        {
            Entities.ToDoItem[] items = null;

            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = client.GetAsync(backendUrl).GetAwaiter().GetResult())
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    items = Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ToDoItem[]>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return View("Index", items);
        }
    }
}