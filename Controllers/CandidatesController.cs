using EFCoreFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using EFCoreFinalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Controllers{

    public class CandidatesController : Controller{
        private readonly DataContext _context;

        public CandidatesController(DataContext context){
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c=>c.Id == id);
            if(candidate == null){
                return NotFound();

            }
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Candidates model, IFormFile? ProfileImg)
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
                    if (!_context.Candidates.Any(c => c.Id == model.Id))
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
        [ValidateAntiForgeryToken]
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
                    model.ResumePath = "/uploads/resumes/" + resumeFileName; 
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
    } 
}