using English.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace English.Controllers
{
    public class HomeController : Controller
    {
        private readonly EnglishDBContext _context;

        public HomeController(EnglishDBContext context)
        {
            _context = context;

        }


        public async Task<IActionResult> Index()
        {
            var word = await _context.Words
                .OrderBy(r => Guid.NewGuid()).Take(1).SingleOrDefaultAsync();

            if (word==null)
            {
              return  RedirectToAction("Create", "Words");
            }

            var examples =
                await _context.Examples.Where(e => e.WordID == word.ID).ToListAsync();
                
            var wordVM = new WordVM();
            wordVM.Word = word;
            wordVM.Word.Examples = examples;

            return View(wordVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
