﻿using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Camunda.Api.Client.History
{
    public abstract class AbstractReport : QueryParameters
    {
        /// <summary>
        /// Specifies the granularity of the report.
        /// </summary>
        public PeriodUnit PeriodUnit;
        /// <summary>
        /// Specifies the type of the report to retrieve.
        /// </summary>
        public ReportType ReportType;
    }

    public enum PeriodUnit
    {
        /// <summary>
        /// Represents a unit for a quarter of the year.
        /// </summary>
        [EnumMember(Value = "quarter")]
        Quarter,

        /// <summary>
        /// Represents a unit for a month of the year.
        /// </summary>
        [EnumMember(Value = "month")]
        Month
    }

    public enum ReportType
    {
        [EnumMember(Value = "duration")]
        Duration,

        [EnumMember(Value = "count")]
        Count
    }

    public enum GroupBy
    {
        [EnumMember(Value = "taskName")]
        TaskName,

        [EnumMember(Value = "processDefinition")]
        ProcessDefinition
    }
}
