using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class againnewfunction
    {
        [FunctionName("againnewfunction")]
        public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Course obj;
            obj = JsonConvert.DeserializeObject<Course>(requestBody);
            log.LogInformation((obj.id).ToString());
            log.LogInformation(obj.name);
            log.LogInformation((obj.rating).ToString());

            return (ActionResult)new OkObjectResult(obj);
        }

    }

    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public double rating;
    }
}
