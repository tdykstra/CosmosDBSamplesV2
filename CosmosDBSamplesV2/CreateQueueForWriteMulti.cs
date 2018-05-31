using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace CosmosDBSamplesV2
{
    public static class CreateQueueForWriteMulti
    {
        [FunctionName("CreateQueueForWriteMulti")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
            [Queue("todoqueueforwritemulti")] out string toDoItems,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            ToDoItem[] toDoItemArray = {
                new ToDoItem { Id = Guid.NewGuid().ToString(), Description = "This row inserted by output binding." }, 
                new ToDoItem { Id = Guid.NewGuid().ToString(), Description = "This row inserted by output binding." } };

            toDoItems = JsonConvert.SerializeObject(toDoItemArray);

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
