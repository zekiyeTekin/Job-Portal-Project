using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Controllers
{
    public class JobPostingController : Controller
    {
        private readonly DataContext _context;

        public JobPostingController(DataContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            var jobPostings = await _context.JobPosting.Include(j=>j.Companies).ToListAsync();
            return View(jobPostings);
        }

         [HttpGet]
        public async Task<IActionResult> GetPost(int id)
        {
            var posting = await _context.JobPosting.FindAsync(id);
            if (posting == null)
            {
                return NotFound();
            }
            return Json(posting);
        }
    }
}
