using System;
using System.Collections.Generic;
using System.Linq;
using JobFlow.Domain.Entities;

namespace JobFlow.Application.Services
{
    public class JobCompatibilityService : IJobCompatibilityService
    {
        // These represent your core skills / tech stack
        private static readonly string[] KeySkills =
        {
            "C#", ".NET", "ASP.NET", "ASP.NET Core", "MVC",
            "Entity Framework", "EF Core", "LINQ",
            "SQL", "SQL Server", "MySQL",
            "JavaScript", "React", "HTML", "CSS",
            "Git", "GitHub"
        };

        public void Evaluate(Job job)
        {
            if (string.IsNullOrWhiteSpace(job.JobDescription))
            {
                // No description, keep whatever is set
                return;
            }

            var descriptionLower = job.JobDescription.ToLowerInvariant();

            var matchedSkills = new List<string>();

            foreach (var skill in KeySkills)
            {
                if (descriptionLower.Contains(skill.ToLowerInvariant()))
                {
                    matchedSkills.Add(skill);
                }
            }

            int totalSkills = KeySkills.Length;
            int matchedCount = matchedSkills.Count;

            if (matchedCount == 0)
            {
                job.Compatibility = JobCompatibility.Low;
                job.CompatibilityReason = "No key skills found in job description.";
                return;
            }

            double ratio = (double)matchedCount / totalSkills;

            if (ratio >= 0.6)
            {
                job.Compatibility = JobCompatibility.High;
            }
            else if (ratio >= 0.3)
            {
                job.Compatibility = JobCompatibility.Medium;
            }
            else
            {
                job.Compatibility = JobCompatibility.Low;
            }

            job.CompatibilityReason =
                $"Matched {matchedCount} of {totalSkills} key skills: {string.Join(", ", matchedSkills)}.";
        }
    }
}
