using System;
using System.Collections.Generic;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<FormViewModel> Forms = new();
        public List<ProcessViewModel> Processes = new();
    }

    public class ProjectListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

    }
}
