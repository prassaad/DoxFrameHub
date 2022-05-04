using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Result;
using DoxFrame.Hub.Core.ProjectAggregate;

namespace DoxFrame.Hub.Core.Interfaces
{
    public interface IPagesRepository
    {
        Task<Result<List<Page>>> GetAllUnpublishedPagesAsync(Guid pageId, string searchString);
        Task<Page> GetPageByIdAsync(Guid projectId, Guid pageId);
        
    }
}
