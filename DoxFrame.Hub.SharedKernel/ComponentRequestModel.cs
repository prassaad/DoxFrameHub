using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoxFrame.Hub.SharedKernel
{
    public class ComponentRequestModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string TransactionIds { get; set; }
        public string TenantId { get; set; }
        public string UserId { get; set; }
        public string Module { get; set; }
         
    }
}
