using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


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
        public async Task<IActionResult> Edit(string? id){
            if(id == null){
                return NotFound();
            }
            var candidate = await _context.Candidates
            .Include(o=>o.JobApply).ThenInclude(j=>j.JobPosting).FirstOrDefaultAsync(c=>c.Id == id);

            //var candidate = await _context.Candidates.FirstOrDefaultAsync(c=>c.Id == id);
            if(candidate == null){
                return NotFound();

            }
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Edit(string id, Candidates model, IFormFile? ProfileImg)
        {
           if (id != model.Id)
            {
                return NotFound();
            }
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
                if(user == null){
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

            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
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
            
            if (isUser != null && isUser.Password == model.Password) 
            {

                Console.WriteLine($"E-posta: {model.Email}, Parola: {model.Password}");

                
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, isUser.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, isUser.Username ?? "")
                    //new Claim("ProfileImg" , isUser.ProfileImg ??"")
                };

                var claimsIdentity = new ClaimsIdentity(userClaims, IdentityConstants.ApplicationScheme);
                
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

               
                return RedirectToAction("Index", "Home"); 
                
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalıdır.");
                Console.WriteLine("Giriş başarısız: Hatalı parola."); 
            }
        }
        else
        {
            ModelState.AddModelError("", "Kullanıcı adı veya parola hatalıdır.");
            Console.WriteLine("Giriş başarısız: Kullanıcı bulunamadı."); 
        }
    }
    else
    {
        Console.WriteLine("Model geçerli değil: " + string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))); 
    }

    return View(model);
}



    } 
}