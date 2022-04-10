using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Api
{
    public class FormsDataController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public FormsDataController(IRepository<Project> repository)
        {
            _repository = repository;
        }

       
        //POST: api/data
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] FormDataDTO data)
        {
            return Json(new { success = true , data = data.Data});
         }

     


    }
}
