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
    public class ReportsRepository : IReportsRepository
    {
         
        private readonly IRepository<Project> _repository;

        public ReportsRepository(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<Report>>> GetAllUnpublishedReportsAsync(Guid projectId, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<Report>>.Invalid(errors);
            }

            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
            if (project == null) return Result<List<Report>>.NotFound();

            var incompleteSpec = new UnpublishedReportsSearchSpec(searchString);

            try
            {
                var items = incompleteSpec.Evaluate(project.Reports).ToList();

                return new Result<List<Report>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Report>>.Error(new[] { ex.Message });
            }
        }
        
        public async Task<Report> GetReportByIdAsync(Guid projectId,Guid reportId)
        {
            var projSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projSpec);

            var reportSpec = new ReportById(reportId);

            var report = reportSpec.Evaluate(project.Reports).FirstOrDefault();

            if (reportSpec!=null)
            {
                return Result<Report>.NotFound();
            }

            return new Result<Report>(report);
        }

        public byte[] ReportLayoutToByteArray(string reportLayout)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] layoutBytes = new byte[1024];
            layoutBytes = utf8.GetBytes(reportLayout);
            return layoutBytes;
        }
 

        public string ReportLayoutToJson(byte[] reportLayout)
        {
            return System.Text.Encoding.Default.GetString(reportLayout);
        }
    }
}
