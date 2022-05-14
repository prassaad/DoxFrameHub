using DoxFrame.Hub.Core.ProjectAggregate;
using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class WorflowViewModel : CreateUpdateWorkflowViewModel
    {
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public static WorflowViewModel FromToWorkflow(Workflow workflow)
        {
            return new WorflowViewModel()
            {
                Id = workflow.Id,
                Key = workflow.Key,
                Title = workflow.Title,
                Name = workflow.Name
                
            };
        }
    }
  
    public class CreateUpdateWorkflowViewModel
    {
        public string Key { get; set; }
    }


    }

