using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class TenantUserProfileViewModel
    {

        public Guid HubUserId { get; set; }
        public Guid TenantId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string DomainName { get; set; }
        public string EnvironmentTag { get; set; }
        public int TotalProjects { get; set; }


    }
}
