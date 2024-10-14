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
        public async Task<IActionResult> Edit(int id, Candidates model)
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
    }   
}