using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Result;
using DoxFrame.Hub.Core.ProjectAggregate;

namespace DoxFrame.Hub.Core.Interfaces
{
    public interface IReportsRepository
    {
        Task<Result<List<Report>>> GetAllUnpublishedReportsAsync(Guid  reportId, string searchString);
        Task<Report> GetReportByIdAsync(Guid projectId, Guid reportId);
       
    }
}
