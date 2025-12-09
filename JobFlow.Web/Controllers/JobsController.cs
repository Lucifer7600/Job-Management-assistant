using System.Linq;
using System.Threading.Tasks;
using JobFlow.Domain.Entities;
using JobFlow.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobFlow.Application.Services;
using JobFlow.Web.Models;


namespace JobFlow.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobFlowDbContext _context;
        private readonly IJobExportService _jobExportService;
        private readonly IJobCompatibilityService _jobCompatibilityService;

        public JobsController(JobFlowDbContext context, IJobExportService jobExportService, IJobCompatibilityService jobCompatibilityService)
        {
            _context = context;
            _jobExportService = jobExportService;
            _jobCompatibilityService = jobCompatibilityService;
        }

        // GET: /Jobs
        public async Task<IActionResult> Index(string? search, JobStatus? status, JobCompatibility? compatibility)
        {
            var query = _context.Jobs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(j =>
                    j.CompanyName.Contains(search) ||
                    j.Position.Contains(search) ||
                    j.Location.Contains(search));
            }

            if (status.HasValue)
            {
                query = query.Where(j => j.Status == status.Value);
            }

            if (compatibility.HasValue)
            {
                query = query.Where(j => j.Compatibility == compatibility.Value);
            }

            var jobs = await query
                .OrderByDescending(j => j.CreatedAt)
                .ToListAsync();

            var vm = new JobListViewModel
            {
                Jobs = jobs,
                Search = search,
                StatusFilter = status,
                CompatibilityFilter = compatibility
            };

            return View(vm);
        }

        // GET: /Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }

            job.CreatedAt = DateTime.UtcNow;

            // Auto-evaluate compatibility based on description
            _jobCompatibilityService.Evaluate(job);

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: /Jobs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: /Jobs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: /Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(job);
            }

            var existingJob = await _context.Jobs.FindAsync(id);
            if (existingJob == null)
            {
                return NotFound();
            }

            // update allowed fields
            existingJob.CompanyName = job.CompanyName;
            existingJob.Position = job.Position;
            existingJob.LinkedInUrl = job.LinkedInUrl;
            existingJob.WayOfApplication = job.WayOfApplication;
            existingJob.Website = job.Website;
            existingJob.Type = job.Type;
            existingJob.Location = job.Location;
            existingJob.Contact = job.Contact;
            existingJob.Status = job.Status;
            existingJob.Compatibility = job.Compatibility;
            existingJob.CompatibilityReason = job.CompatibilityReason;
            existingJob.JobRelatedDocs = job.JobRelatedDocs;
            existingJob.LastInteractionDate = job.LastInteractionDate;
            existingJob.LastInteractionNote = job.LastInteractionNote;

            _jobCompatibilityService.Evaluate(existingJob);



            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Jobs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: /Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportToExcel()
        {
            var bytes = await _jobExportService.ExportJobsToExcelAsync();
            var fileName = $"Jobs_{DateTime.UtcNow:yyyyMMdd_HHmm}.xlsx";

            return File(
                bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

    }
}
