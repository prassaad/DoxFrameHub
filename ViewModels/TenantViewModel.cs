using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class TenantViewModel
    {
        public Guid HubUserId { get; set; }
        public string DomainName { get; set; }
        public string Region { get; set; }
        public string EnvironmentTag { get; set; }
    }
}
