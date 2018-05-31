using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CosmosDBSamplesV2
{
    public static class CreateQueueForLookup
    {
        [FunctionName("CreateQueueForLookup")]
        public static async 
            Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, 
            [Queue("todoqueueforlookup")] IAsyncCollector<ToDoItemLookup> toDoItemLookUps,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            await toDoItemLookUps.AddAsync(new ToDoItemLookup { ToDoItemId = "task1" });

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
