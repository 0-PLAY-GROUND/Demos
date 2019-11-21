using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using English.Models; 

namespace English.Controllers
{
    public class ExamplesController : Controller
    {
        private readonly EnglishDBContext _context;

        public ExamplesController(EnglishDBContext context)
        {
            _context = context;
        }

        // GET: Examples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Examples.ToListAsync());
        }

        // GET: Examples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Examples
                .FirstOrDefaultAsync(m => m.ID == id);
            if (example == null)
            {
                return NotFound();
            }

            return View(example);
        }

        // GET: Examples/Create
        public IActionResult Create(int WordID)
        {
            return View();
        }

        // POST: Examples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ExampleText,ExampleTranslation,WordID")] Example example)
        {
            if (ModelState.IsValid)
            {
                _context.Add(example);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(example);
        }

        // GET: Examples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Examples.FindAsync(id);
            if (example == null)
            {
                return NotFound();
            }
            return View(example);
        }

        // POST: Examples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExampleText,ExampleTranslation")] Example example)
        {
            if (id != example.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(example);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExampleExists(example.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(example);
        }

        // GET: Examples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Examples
                .FirstOrDefaultAsync(m => m.ID == id);
            if (example == null)
            {
                return NotFound();
            }

            return View(example);
        }

        // POST: Examples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var example = await _context.Examples.FindAsync(id);
            _context.Examples.Remove(example);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExampleExists(int id)
        {
            return _context.Examples.Any(e => e.ID == id);
        }
    }
}
