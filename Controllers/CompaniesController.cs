using System.Security.Claims;
using EFCoreFinalApp.Data;
using EFCoreFinalApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Company")]
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
        [Authorize(Roles = "Company")]
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


        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> listPostCompany(int companyId)
        {
           var company = _context.Companies.Find(companyId);
            var jobPostings = await _context.JobPosting
                .Where(jp => jp.CompaniesId == companyId)
                .ToListAsync();
            ViewBag.CompanyName = company.Name;

            if (jobPostings == null || !jobPostings.Any())
            {
                return NotFound(); 
            }

            return View(jobPostings); 
        }



















        [HttpGet("Companies/Login")]
        public IActionResult Login(){
           
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("JobApply","Index");
            }
            return View();
        }

        [HttpGet("Companies/Register")]
        public IActionResult Register(){
            return View();
        }

        [HttpPost("Companies/Register")]
        public async Task<IActionResult> Register(Companies model, Role role){

            if(ModelState.IsValid){
                var user = await _context.Companies.FirstOrDefaultAsync(x=>x.Name == model.Name || x.Email == model.Email);
                if(user == null){

                     model.Role = Role.Company;
                    _context.Companies.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }else{
                    ModelState.AddModelError("", "UserName ya da Email adresi kullanımda");
                }
            }
            return View(model);
        }


            public async Task<IActionResult> Logout(){

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost("Companies/Login")]
        public async Task<IActionResult>Login(LoginViewModel model){

            if(ModelState.IsValid){

                var isCompany = await _context.Companies.FirstOrDefaultAsync(x=>x.Email == model.Email && x.Password == model.Password);

                if(isCompany != null){
                    var companyClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, isCompany.Name ?? ""),  
                new Claim(ClaimTypes.NameIdentifier, isCompany.Id.ToString()),
                new Claim(ClaimTypes.Role, isCompany.Role.ToString())
            };

                    companyClaims.Add(new Claim(ClaimTypes.Role, isCompany.Role.ToString()));

                    companyClaims.Add(new Claim(ClaimTypes.NameIdentifier, isCompany.Id.ToString()));
                    companyClaims.Add(new Claim(ClaimTypes.Name, isCompany.Name ?? ""));

                    var claimsIdentity = new ClaimsIdentity(companyClaims, CookieAuthenticationDefaults.AuthenticationScheme);


                    var authProporties = new AuthenticationProperties{IsPersistent =true};

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),authProporties);
                    
                   
                        return RedirectToAction("Index", "JobApply"); 
                    

                    
                }
                else{
                ModelState.AddModelError("","Kullanıcı adı veya parola hatalıdır.");
             }

            }
            return View(model);
        }





       
    }
}