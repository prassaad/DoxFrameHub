using Ardalis.GuardClauses;
using DoxFrame.Hub.Core.AccountAggregate.Events;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace DoxFrame.Hub.Core.AccountAggregate
{
    // Tenant is also a Customer for BA / IT Companines / Consultants who Dev. Forms, Reps etc.

    public class Tenant : Account, IAggregateRoot
    {
        
        public string DomainName { get; set; }  // in.doxframe.com .us.doxframe.com ** Cant be renamed once after created
        public string Region { get; set; } // ASIA, AUS , EU, US 
        public string EnvironmentTag { get; set; } // Dev, Stag, Prod
 
    

        private List<Project> _projects = new List<Project>();
        public IEnumerable<Project> projects => _projects.AsReadOnly();

        public Tenant(string domainName, string region)
        {
            DomainName = Guard.Against.NullOrEmpty(domainName, nameof(domainName));
            Region = Guard.Against.NullOrEmpty(region, nameof(region));

        }
        public void AddProject(Project newProject)
        {
            Guard.Against.Null(newProject, nameof(newProject));
            _projects.Add(newProject);

        }
        public void RemoveProject(Project rmProject)
        {
            _projects.Remove(rmProject);

            var projectRemovedEvent = new ProjectRemovedEvent(this, rmProject);
            Events.Add(projectRemovedEvent);
        }


    }
}
