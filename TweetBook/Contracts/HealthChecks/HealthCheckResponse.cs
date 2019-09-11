using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Diagnostics;

namespace TweetBook.Contracts.HealthChecks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public IEnumerable<HealthCheck> Checks { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class HealthCheck
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
    }
}
