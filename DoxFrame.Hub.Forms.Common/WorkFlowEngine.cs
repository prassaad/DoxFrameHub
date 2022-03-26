using Camunda.Api.Client;
using DoxFrame.Hub.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace DoxFrame.Hub.Infrastructure
{
    public class CamundaWorkFlowEngine : ICamundaClient
    {
        private readonly ILogger<CamundaClient> _logger;
          
        public CamundaWorkFlowEngine(ILogger<CamundaClient> logger)
        {
            _logger = logger;
        }

        public async Task SendRequestAsync()
        {
            var client = CamundaClient.Create("http://localhost:8080/engine-rest");
            var process = await client.ProcessInstances.Query().List();


            // Start Process
            System.Collections.Generic.Dictionary<string, VariableValue> numberNames = new System.Collections.Generic.Dictionary<string, VariableValue>();
            numberNames.Add("Model", VariableValue.FromObject("Audi"));
            await client.ProcessDefinitions.ByKey("Process_1").StartProcessInstance(new Camunda.Api.Client.ProcessDefinition.StartProcessInstance() { Variables = numberNames });

            // Complete Step


            // List all Taks
            await client.UserTasks.Query(new Camunda.Api.Client.UserTask.TaskQuery() { }).List();

            // Complete a Task

            // build query
            var externalTaskQuery = new Camunda.Api.Client.ExternalTask.ExternalTaskQuery() { Active = true, TopicName = "MyTask" };

            // add some sorting
            externalTaskQuery
                .Sort(Camunda.Api.Client.ExternalTask.ExternalTaskSorting.TaskPriority, SortOrder.Descending)
                .Sort(Camunda.Api.Client.ExternalTask.ExternalTaskSorting.LockExpirationTime);

            // request external tasks according to query
            System.Collections.Generic.List<Camunda.Api.Client.ExternalTask.ExternalTaskInfo> tasks = await client.ExternalTasks.Query(externalTaskQuery).List();

            _logger.LogWarning($"Camunda {0} Message {process}.");
        }

       
    }
}
