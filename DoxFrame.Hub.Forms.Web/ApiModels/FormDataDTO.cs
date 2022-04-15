﻿using DoxFrame.Hub.Core.ProjectAggregate;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoxFrame.Hub.Web.ApiModels
{
    // ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
    public class FormDataDTO 
    {
        public string Data { get; set; }
             
    }
    // Creation DTOs should not include an ID if the ID will be generated by the back end
   
    public class UpdateFormDataDTO
    {
        public Guid ProjectId { get; set; }
        public Guid FormId { get; set; }
        public Guid DocumentId { get; set; }
        public string JsonObject { get; set; }
  
    }
    public class RemoveFormDataDTO
    { 
        public Guid ProjectId { get; set; }
        public Guid FormId { get; set; }
        public Guid DocumentId { get; set; }

    }
 
}