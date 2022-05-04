using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System.Linq;
using System.Text;

namespace DoxFrame.Hub.Core.Services
{
    public class FormsRepository : IFormsRepository 
    {
         
        private readonly IRepository<Project> _repository;

        public FormsRepository(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<Form>>> GetAllUnpublishedFormsAsync(Guid projectId, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<Form>>.Invalid(errors);
            }

            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
            if (project == null) return Result<List<Form>>.NotFound();

            var incompleteSpec = new UnpublishedFormsSearchSpec(searchString);

            try
            {
                var items = incompleteSpec.Evaluate(project.Forms).ToList();

                return new Result<List<Form>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Form>>.Error(new[] { ex.Message });
            }
        }
        public async Task<Result<Form>> GetNextUnpublishedFormAsync(Guid projectId)
        {
            var fromSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(fromSpec);

            var unpublishedFormsSpec = new UnpublishedFormsSpec();

            var items = unpublishedFormsSpec.Evaluate(project.Forms).ToList();

            if (!items.Any())
            {
                return Result<Form>.NotFound();
            }

            return new Result<Form>(items.First());
        }
        public async Task<Form> GetFormByIdAsync(Guid projectId,Guid formId)
        {
            var projSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projSpec);

            var formSpec = new FormById(formId);

            var form = formSpec.Evaluate(project.Forms).FirstOrDefault();

            if (formSpec!=null)
            {
                return Result<Form>.NotFound();
            }

            return new Result<Form>(form);
        }

        public byte[] FormLayoutToByteArray(string formLayout)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] layoutBytes = new byte[1024];
            layoutBytes = utf8.GetBytes(formLayout);
            return layoutBytes;
        }
 

        public string FormLayoutToJson(byte[] formLayout)
        {
            return System.Text.Encoding.Default.GetString(formLayout);
        }
    }
}
