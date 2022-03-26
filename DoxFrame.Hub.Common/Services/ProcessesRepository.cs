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
    public class ProcessesRepository : IProcessesRepository 
    {
         
        private readonly IRepository<Project> _repository;

        public ProcessesRepository(IRepository<Project> repository)
        {
            _repository = repository;
        }
     
        public byte[] ProcessModelLayoutToByteArray(string ProcessModelLayout)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] layoutBytes = new byte[1024];
            layoutBytes = utf8.GetBytes(ProcessModelLayout);
            return layoutBytes;
        }
 
        public string ProcessModelLayoutToXml(byte[] processModelLayout)
        {
            return System.Text.Encoding.Default.GetString(processModelLayout);
        }
    }
}
