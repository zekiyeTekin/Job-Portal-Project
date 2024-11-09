using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authorization;

namespace EFCoreFinalApp.Controllers
{
    public class JobPostingController : Controller
    {
        private readonly DataContext _context;

        public JobPostingController(DataContext context)
        {
            _context = context;
        }


         public async Task<IActionResult> Index(string searchString)
        {
            var jobPostings = from j in _context.JobPosting.Include(j => j.Companies)
                      select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobPostings = jobPostings.Where(s => s.Title.ToLower().Contains(searchString.ToLower()));
            }
            ViewBag.CurrentSearch = searchString;
             return View(await jobPostings.ToListAsync());
            
        }

         [HttpGet]
        public async Task<IActionResult> GetPost(int id)
        {
            var posting = await _context.JobPosting
            .Include(j => j.Companies).FirstOrDefaultAsync(j => j.Id == id);
            if (posting == null)
            {
                return NotFound("Job posting not found");
            }
            return Json(posting);
        }

        public async Task<IActionResult> Details(int id)
        {
            var jobPosting = await _context.JobPosting.Include(j => j.JobApply).ThenInclude(ja=>ja.Candidates).
            Include(j=>j.Companies).FirstOrDefaultAsync(j => j.Id == id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }


         public async Task<IActionResult> Create()
        {
            var companies = await _context.Companies.ToListAsync();
            if (companies == null || !companies.Any())
            {
                ViewBag.Companies = new SelectList(Enumerable.Empty<Companies>(), "Id", "Name");
            }
            else
            {
                ViewBag.Companies = new SelectList(companies, "Id", "Name");
            }
            return View(new JobPosting());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Create(JobPosting jobPosting)
        {
            jobPosting.PostedDate = DateTime.Now;

            //Console.WriteLine($"Title: {jobPosting.Title}, Description: {jobPosting.Description}, Location: {jobPosting.Location}, Salary: {jobPosting.Salary}, CompaniesId: {jobPosting.CompaniesId}, ClosingDate: {jobPosting.ClosingDate}");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState hataları:");
                foreach (var entry in ModelState)
                {
                    Console.WriteLine($"Key: {entry.Key}, Errors: {string.Join(", ", entry.Value.Errors.Select(e => e.ErrorMessage))}");
                }
            }

            ViewBag.Companies = new SelectList(await _context.Companies.ToListAsync(), "Id", "Name", jobPosting.CompaniesId);

            //Console.WriteLine($"CompaniesId: {jobPosting.CompaniesId}");

            _context.JobPosting.Add(jobPosting);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Company")]
          public IActionResult JobApplications(int jobPostingId)
        {
            var jobPosting = _context.JobPosting
                .Include(j => j.JobApply)
                .ThenInclude(ja => ja.Candidates)
                .FirstOrDefault(j => j.Id == jobPostingId);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int applicationId, string newStatus)
        {
            
            var application = _context.JobApply
            .FirstOrDefault(a => a.Id == applicationId);
            
            if (application == null)
            {
                return NotFound(); 
            }

            
            application.Status = newStatus;
            _context.SaveChanges(); 

            
            return RedirectToAction("JobApplications", "JobPosting", new { jobPostingId = application.JobPostingId });
        }



        



    }   
}
