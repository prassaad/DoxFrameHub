using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Process : Document, IAggregateRoot
    {
        public string Key { get; set; } // The key of the process definition, i.e.the id of the BPMN 2.0 XML process definition.
        public string Name { get; set; } // The name of the process definition
        public string VersionNumber { get; set; } // The version of the process definition that the engine assigned to it.
        public string Resource { get; set; } // The file name of the process definition.
        public string DeploymentId { get; set; } // String  The deployment id of the process definition.
        public string Diagram { get; set; } // The file name of the process definition diagram, if it exists.
        public bool Suspended { get; set; } // A flag indicating whether the definition is suspended or not.
        public string VersionTag { get; set; } // The version tag of the process definition.

        public void Update(Process process)
        {
            Key = process.Key;
            Name = process.Name;
            Title = process.Title;
            Description = process.Description;
            Events.Add(new ProcessUpdatedEvent(this));
        }
        
         
    }
}
