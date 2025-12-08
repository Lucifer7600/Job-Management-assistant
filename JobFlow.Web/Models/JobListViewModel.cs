using System.Collections.Generic;
using JobFlow.Domain.Entities;

namespace JobFlow.Web.Models
{
    public class JobListViewModel
    {
        public List<Job> Jobs { get; set; } = new();

        public string? Search { get; set; }
        public JobStatus? StatusFilter { get; set; }
        public JobCompatibility? CompatibilityFilter { get; set; }
    }
}
