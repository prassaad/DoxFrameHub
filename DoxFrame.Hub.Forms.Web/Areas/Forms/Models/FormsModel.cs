using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Areas.Forms.Models
{
    public class FormsModel
    {
        public FormsModel(IEnumerable<string> formGroups)
        {
            FormGroups = formGroups;
        }
        public IEnumerable<string> FormGroups { get; set; }
    }
}
