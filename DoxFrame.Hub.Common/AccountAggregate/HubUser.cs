using Ardalis.GuardClauses;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DoxFrame.Hub.Core.AccountAggregate
{
    // Tenant is also a Customer for DoxFrame like  BA / IT Companines / Consultants

    public class HubUser : Account, IAggregateRoot
    {
        public string Type { get; set; } // Individual / Firm
        public string SID { get; set; } // Auth Id from Identity Server
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string ProfileImage { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string StaffId { get; set; } // In case to identify by HR/ payroll ID
        public bool IsAccountAdmin { get; set; }
        public bool IsHubAdmin { get; set; }
        public int ITExperience { get; set; }
        public int NoNITExperience { get; set; }
        public int TotalProjectsWorked { get; set; }
        public string ResumeDocPath { get; set; }
        public bool IsCertified { get; set; }

        private List<Tenant> _tenants = new List<Tenant>();
        public IEnumerable<Tenant> Tenants => _tenants.AsReadOnly();
  
        // Consutructor
        public HubUser(string name, string email, string mobile, string type)
        {

            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Mobile = Guard.Against.NullOrEmpty(mobile, nameof(mobile));
            Type = Guard.Against.NullOrEmpty(type, nameof(type));
            Key = DoxFrame.Hub.SharedKernel.Helper.RandomSecureKey();

        }
     

    }
}
