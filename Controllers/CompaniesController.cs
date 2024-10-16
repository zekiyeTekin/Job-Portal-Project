using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Controllers
{
    public class CompaniesController : Controller{
        private readonly DataContext _context;

        public CompaniesController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(String industryFilter){
            var companies = from c in _context.Companies
                        select c;

        // Industry'e göre filtreleme yapılıyor
        if (!string.IsNullOrEmpty(industryFilter))
        {
            companies = companies.Where(c => c.Industry == industryFilter);
        }

        // Tüm şirketleri ViewBag'e atıyorum ki dropdown menüde gösterebileyim
        ViewBag.Industry = await _context.Companies
            .Select(c => c.Industry)
            .Distinct()
            .ToListAsync();
        
        ViewBag.SelectedIndustry = industryFilter;


            //return View(await companies.ToListAsync());
            return View(await companies.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Json(company);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Companies model, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    var imageFileName = Path.GetFileName(logo.FileName);
                    var imageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/images", imageFileName);
                    using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    {
                        await logo.CopyToAsync(stream);
                    }
                    model.Logo = "/uploads/images/" + imageFileName; 
                }

                
                _context.Companies.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}