using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Controllers{
    public class JobApplyController : Controller{

        private readonly DataContext _context;

        public JobApplyController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index()
            {
                var jobApplies = await _context.JobApply
                    .Include(x => x.Candidates)
                    .Include(x => x.JobPosting)
                    .ToListAsync();
                return View(jobApplies);
            }

        [HttpGet]
        public IActionResult Create(int jobPostingId)
        {
            var jobApply = _context.JobPosting.Find(jobPostingId);
            
            if (jobApply == null)
            {
                return NotFound(); 
            }

            ViewBag.JobPosting = jobApply;        
            var jobApplies = new JobApply
            {
                JobPostingId = jobApply.Id,
                CandidatesId = 2,
                Status = "Beklemede" 
            };
            return View(jobApplies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobApply jobApply)
        {
            Console.WriteLine($"CandidatesId: {jobApply.CandidatesId}");
            Console.WriteLine($"JobPostingId: {jobApply.JobPostingId}");
            Console.WriteLine($"Status: {jobApply.Status}");

             if (string.IsNullOrEmpty(jobApply.Status))
                {
                    jobApply.Status = "Beklemede"; 
                }
                        
            
            if (ModelState.IsValid)
            {
                jobApply.ApplyDate = DateTime.Now;
                _context.JobApply.Add(jobApply);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors)){
                    Console.WriteLine(error.ErrorMessage); 
                    }
            }
            
            return View(jobApply);
        }


      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var jobApply = await _context.JobApply.FindAsync(id);
            if (jobApply == null)
            {
                return NotFound();
            }

            
            _context.JobApply.Remove(jobApply);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("Edit", "Candidates", new { id = jobApply.CandidatesId });
        }


        
    }
}