using System;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using JobFlow.Application.Services;
using JobFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobFlow.Infrastructure.Services
{
    public class JobExportService : IJobExportService
    {
        private readonly JobFlowDbContext _context;

        public JobExportService(JobFlowDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]> ExportJobsToExcelAsync()
        {
            var jobs = await _context.Jobs
                .OrderByDescending(j => j.CreatedAt)
                .ToListAsync();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Jobs");

            // Header row
            worksheet.Cell(1, 1).Value = "Company Name";
            worksheet.Cell(1, 2).Value = "Position";
            worksheet.Cell(1, 3).Value = "LinkedIn";
            worksheet.Cell(1, 4).Value = "Way of Application";
            worksheet.Cell(1, 5).Value = "Website";
            worksheet.Cell(1, 6).Value = "Type";
            worksheet.Cell(1, 7).Value = "Location";
            worksheet.Cell(1, 8).Value = "Contact";
            worksheet.Cell(1, 9).Value = "Status";
            worksheet.Cell(1, 10).Value = "Job Related Docs";
            worksheet.Cell(1, 11).Value = "Last Interaction";
            worksheet.Cell(1, 12).Value = "Job Compatibility";

            var row = 2;

            foreach (var job in jobs)
            {
                worksheet.Cell(row, 1).Value = job.CompanyName;
                worksheet.Cell(row, 2).Value = job.Position;
                worksheet.Cell(row, 3).Value = job.LinkedInUrl;
                worksheet.Cell(row, 4).Value = job.WayOfApplication;
                worksheet.Cell(row, 5).Value = job.Website;
                worksheet.Cell(row, 6).Value = job.Type;
                worksheet.Cell(row, 7).Value = job.Location;
                worksheet.Cell(row, 8).Value = job.Contact;
                worksheet.Cell(row, 9).Value = job.Status.ToString();
                worksheet.Cell(row, 10).Value = job.JobRelatedDocs;

                var lastInteraction = job.LastInteractionDate.HasValue
                    ? $"{job.LastInteractionDate.Value.ToLocalTime():yyyy-MM-dd}: {job.LastInteractionNote}"
                    : string.Empty;

                worksheet.Cell(row, 11).Value = lastInteraction;

                var compatibilityText = string.IsNullOrWhiteSpace(job.CompatibilityReason)
                    ? job.Compatibility.ToString()
                    : $"{job.Compatibility} - {job.CompatibilityReason}";

                worksheet.Cell(row, 12).Value = compatibilityText;

                row++;
            }

            // Make it look a bit nicer
            var headerRange = worksheet.Range(1, 1, 1, 12);
            headerRange.Style.Font.Bold = true;
            worksheet.Columns().AdjustToContents();

            using var stream = new System.IO.MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
