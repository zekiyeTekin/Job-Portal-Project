using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace EFCoreFinalApp.Controllers{

    public class CandidatesController : Controller{
        private readonly DataContext _context;

        public CandidatesController(DataContext context){
            _context = context;
        }

        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var candidate = await _context.Candidates
            .Include(o => o.JobApply)
            .ThenInclude(j => j.JobPosting)
            .FirstOrDefaultAsync(c => c.Id == id);

            Console.WriteLine(candidate);

            
            if(candidate == null){
                return NotFound();

            }
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Edit(int id, Candidates model, IFormFile? ProfileImg)
        {
           if (id != model.Id)
            {
                return NotFound();
            }
            Console.WriteLine(id);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Candidates.Any(o => o.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Create(Candidates model, IFormFile ProfileImg, IFormFile ResumePath)
        {
            if (ModelState.IsValid)
            {
                
                if (ResumePath != null)
                {
                    var resumeFileName = Path.GetFileName(ResumePath.FileName);
                    var resumeFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/resumes", resumeFileName);
                    using (var stream = new FileStream(resumeFilePath, FileMode.Create))
                    {
                        await ResumePath.CopyToAsync(stream);
                    }
                    model.ResumePath = "uploads/resumes/" + resumeFileName; 
                }

                
                if (ProfileImg != null)
                {
                    var imageFileName = Path.GetFileName(ProfileImg.FileName);
                    var imageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/images", imageFileName);
                    using (var stream = new FileStream(imageFilePath, FileMode.Create))
                    {
                        await ProfileImg.CopyToAsync(stream);
                    }
                    model.ProfileImg = "/uploads/images/" + imageFileName; 
                }

                _context.Candidates.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


























        [HttpGet("/Candidates/Login")]
        public IActionResult Login(){
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public IActionResult Register(){
            return View();
        }

        [HttpPost("/Candidates/Register")]
        public async Task<IActionResult> Register(Candidates model,Role role){

            if(ModelState.IsValid){
                var user = await _context.Candidates.FirstOrDefaultAsync(x=>x.Name == model.Name || x.Email == model.Email);
                if(user == null)
                {
                    model.Role = Role.Candidate;
                    _context.Candidates.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }else{
                    ModelState.AddModelError("", "UserName ya da Email adresi kullanımda");
                }
            }
            return View(model);
        }


            public async Task<IActionResult> Logout(){

            await HttpContext.SignOutAsync((CookieAuthenticationDefaults.AuthenticationScheme));
            return RedirectToAction("Login");
        }

 

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser = await _context.Candidates
            .FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);


                if (isUser != null)
                {
                    
                        Console.WriteLine($"E-posta: {model.Email}, Parola: {model.Password}");

                        
                        var userClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, isUser.Role.ToString()),
                            new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()),
                            new Claim(ClaimTypes.Name, isUser.Username ?? ""),
                            new Claim("ProfileImg", isUser.ProfileImg ?? "/uploads/images/profile_(7).jpg")
                        };

                        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                        
                        var authProperties = new AuthenticationProperties { IsPersistent = true };
                        
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        
                    
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                        var userRole = isUser.Role;
                        Console.WriteLine(userRole);

                       

                        if(userRole == Role.Candidate){
                            return RedirectToAction("Index", "Home"); 
                        }
                        //TODO: return değeri accesdenied olarak güncellenecek
                        else{
                            return RedirectToAction("Index", "Home"); 
                        }
                    }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya parola hatalıdır."); 
                }
            }
            return View(model);
        }

            } 
        }