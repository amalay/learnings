using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Models
{
    //public class IndexModel
    //{
    //    private static string backendDNSName = $"{Environment.GetEnvironmentVariable("ToDoServiceName")}";
    //    private static Uri backendUrl = new Uri($"http://{backendDNSName}:{Environment.GetEnvironmentVariable("ApiHostPort")}/api/todo");

    //    //public Entities.ToDoItem[] Items = new Entities.ToDoItem[] { };

    //    public Entities.ToDoItem[] OnGet()
    //    {
    //        Entities.ToDoItem[] items = null;

    //        HttpClient client = new HttpClient();

    //        using (HttpResponseMessage response = client.GetAsync(backendUrl).GetAwaiter().GetResult())
    //        {
    //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //            {
    //                items = Newtonsoft.Json.JsonConvert.DeserializeObject<Entities.ToDoItem[]>(response.Content.ReadAsStringAsync().Result);
    //            }
    //        }

    //        return items;
    //    }
    //}
}
