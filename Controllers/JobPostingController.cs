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
    }
}
