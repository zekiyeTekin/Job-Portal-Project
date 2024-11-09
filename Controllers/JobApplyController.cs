using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Create(int jobPostingId)
        {
            var jobPosting = await _context.JobPosting.FindAsync(jobPostingId);

            if (jobPosting == null)
            {
                return NotFound(); 
            }
            
            ViewBag.Candidates = await _context.Candidates
                              .Select(c => new { c.Id, c.Name })
                              .ToListAsync();
            //ViewBag.JobPosting = new SelectList(await _context.JobPosting.ToListAsync(), "Id","Title");

             var jobApply = new JobApply 
            { 
                JobPosting = jobPosting,
                JobPostingId = jobPostingId 
            };

            return View(jobApply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobApply jobApply)
        {
            var existingApplication = await _context.JobApply
        .Where(j => j.CandidatesId == jobApply.CandidatesId && j.JobPostingId == jobApply.JobPostingId)
        .FirstOrDefaultAsync();

        if (existingApplication != null)
        {
            
        ViewBag.ErrorMessage = "Bu ilana zaten başvuru yapmıştınız.";
        
        ViewBag.Candidates = await _context.Candidates
                              .Select(c => new { c.Id, c.Name })
                              .ToListAsync();
        
        return View(jobApply);
        }
            
                jobApply.ApplyDate = DateTime.Now;
                jobApply.Status = "Başvurunuz alındı";
                jobApply.Candidates = await _context.Candidates.FindAsync(jobApply.CandidatesId);
                jobApply.JobPosting = await _context.JobPosting.FindAsync(jobApply.JobPostingId);

                _context.JobApply.Add(jobApply);
                await _context.SaveChangesAsync();

               
                return RedirectToAction("Index");

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