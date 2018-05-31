using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace CosmosDBSamplesV2
{
    public static class WriteDocFromPOCO
    {
        [FunctionName("WriteDocFromPOCO")]
        public static void Run(
            [QueueTrigger("todoqueueforwrite")] ToDoItem toDoItem,
            [CosmosDB("ToDoItems","Items", 
                ConnectionStringSetting = "CosmosDBConnection")]out dynamic document,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed Id={toDoItem?.Id}, Description={toDoItem.Description}");

            document = toDoItem;
        }
    }
}
