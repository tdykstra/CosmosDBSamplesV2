using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CosmosDBSamplesV2
{
    public static class CreateQueueForWrite
    {
        [FunctionName("CreateQueueForWrite")]
        public static async 
            Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
            [Queue("todoqueueforwrite")] IAsyncCollector<ToDoItem> toDoItemLookUps,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            await toDoItemLookUps.AddAsync(new ToDoItem { Id = Guid.NewGuid().ToString(), Description="This row inserted by output binding." });

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
