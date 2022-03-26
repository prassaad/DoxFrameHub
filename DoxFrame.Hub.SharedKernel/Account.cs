using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoxFrame.Hub.SharedKernel
{
    public class Account : BaseEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; } // >6 <12
        public string Name { get; set; }
        public string Level { get; set; } // Startup // etc
        public string IdentityUri { get; set; } // Website / Social Identity
        public string Logo { get; set; }
        public string Domain { get; set; } // BSFI // Insurance // etc 
        public int NoOfTenats { get; set; }
        // Profile Releated
        public DateTime FiscalYearStartDate { get; set; }
        public DateTime FiscalYearEndDate { get; set; }
        public bool IsTrial { get; set; }
        public string LicenseName { get; set; }
        public string NoOfCompanies { get; set; }
        public string NoOfBusinessLocations { get; set; }
        public int TeamSizeLimit { get; set; }
        // Storage for files etc.
        //Storage URL
        //User Name
        //Storage Size(MB):
        //// DB 
        //Provider
        //HostServer
        //Port
        //UID
        //Password
        public bool isActive { get; set; }
    }
}
