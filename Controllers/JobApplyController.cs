using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Controllers{
    public class JobApplyController : Controller{

        private readonly DataContext _context;

        public JobApplyController(DataContext context){
            _context = context;
        }

        // public async Task<IActionResult> Index()
        // {
        //     var JobApply = await _context.JobApply.Include(x=>x.Candidates).Include(x=>x.JobPosting).ToListAsync();
        //     return View(JobApply);
        // }

        [HttpGet]
        public IActionResult Create(int jobPostingId)
        {
            var jobApply = new JobApply { JobPostingId = jobPostingId };
            if (jobApply == null)
            {
                return NotFound();
            }
            
            var jobApplies = new JobApply
            {
                JobPostingId = jobApply.Id,
                Status = "Beklemede" 
            };
            return View(jobApplies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobApply jobApply)
        {
            if (ModelState.IsValid)
            {
                jobApply.ApplyDate = DateTime.Now;
                _context.JobApply.Add(jobApply);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "JobPosting"); // Başarıyla kaydedildiğinde yönlendirin
            }
            return View(jobApply);
        }
   
    }
}