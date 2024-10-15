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

        // Tüm şirketleri ViewBag'e atıyoruz ki dropdown menüde gösterebilelim
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

        


    }
}