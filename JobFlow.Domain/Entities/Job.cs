using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace JobFlow.Domain.Entities;

public enum JobStatus
{
    New = 0,
    Shortlisted,
    Applied,
    Interview,
    Offer,
    Rejected,
    OnHold
}

public enum JobCompatibility
{
    Low = 0,
    Medium,
    High
}

public class Job
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Position { get; set; } = string.Empty;

    [MaxLength(500)]
    [Url]
    public string LinkedInUrl { get; set; } = string.Empty;

    [MaxLength(100)]
    public string WayOfApplication { get; set; } = string.Empty;

    [MaxLength(500)]
    [Url]
    public string Website { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Location { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Contact { get; set; } = string.Empty;

    public JobStatus Status { get; set; } = JobStatus.New;
    public JobCompatibility Compatibility { get; set; } = JobCompatibility.Medium;

    [MaxLength(1000)]
    public string CompatibilityReason { get; set; } = string.Empty;

    [MaxLength(500)]
    public string JobRelatedDocs { get; set; } = string.Empty;

    public DateTime? LastInteractionDate { get; set; }

    [MaxLength(1000)]
    public string LastInteractionNote { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(4000)]
    public string JobDescription { get; set; } = string.Empty;

}


