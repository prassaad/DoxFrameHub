using DoxFrame.Hub.SharedKernel;
using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class ComponentsViewModel  
    {
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string ComponentType { get; set; }


        public static ComponentsViewModel FromToComponent(Component component)
        {
            return new ComponentsViewModel()
            {
                Id = component.Id,
                Title = component.Title,
                ProjectId = component.ProjectId,
                ComponentType = component.ComponentType
                
            };
        }
    }
  
   

    }

