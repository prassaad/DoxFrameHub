using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Result;
using DoxFrame.Hub.Core.ProjectAggregate;

namespace DoxFrame.Hub.Core.Interfaces
{
    public interface IFormsRepository
    {
        Task<Result<Form>> GetNextUnpublishedFormAsync(Guid formId);
        Task<Result<List<Form>>> GetAllUnpublishedFormsAsync(Guid formId, string searchString);
        Task<Form> GeFormByIdAsync(Guid projectId, Guid formId);
        //Task<Form> GeFormLayoutByIdAsync(Guid projectId, Guid formId);
    }
}
