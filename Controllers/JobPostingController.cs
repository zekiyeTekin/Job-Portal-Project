using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Create(JobPosting jobPosting)
        {
            jobPosting.PostedDate = DateTime.Now;

            
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState hataları:");
                foreach (var entry in ModelState)
                {
                    Console.WriteLine($"Key: {entry.Key}, Errors: {string.Join(", ", entry.Value.Errors.Select(e => e.ErrorMessage))}");
                }

                ViewBag.Companies = new SelectList(await _context.Companies.ToListAsync(), "Id", "Name", jobPosting.CompaniesId);
                return View(jobPosting);
            }

            Console.WriteLine($"CompaniesId: {jobPosting.CompaniesId}"); 

           
            _context.JobPosting.Add(jobPosting);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Details(int id)
        {
            var jobPosting = await _context.JobPosting.Include(j => j.JobApply).ThenInclude(ja=>ja.Candidates).FirstOrDefaultAsync(j => j.Id == id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }


    }   
}
