using DoxFrame.Hub.Core.ProjectAggregate;
using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class ProcessViewModel : CreateUpdateProcessViewModel
    {
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public static ProcessViewModel FromToProcess(Process process)
        {
            return new ProcessViewModel()
            {
                Id = process.Id,
                Key = process.Key,
                Title = process.Title,
                Name = process.Name
                
            };
        }
    }
  
    public class CreateUpdateProcessViewModel
    {
        public string Key { get; set; }
    }


    }

