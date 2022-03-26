using DoxFrame.Hub.Core.ProjectAggregate;
using System;

namespace DoxFrame.Hub.Web.ViewModels
{
    public class FormViewModel : CreateUpdateFormViewModel
    {
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static FormViewModel FromToForm(Form form)
        {
            return new FormViewModel()
            {
                Id = form.Id,
                Key = form.Key,
                Title = form.Title,
                OperationType = form.OperationType,
                Description = form.Description,
                IsPublished = form.isPublished
            };
        }
    }
  
    public class CreateUpdateFormViewModel
    {
        public string Key { get; set; }
        public string OperationType { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }


    }
}
