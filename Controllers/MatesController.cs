#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMate.Data;
using MvcMate.Models;

namespace MvcMate.Controllers
{
    public class MatesController : Controller
    {
        private readonly MateContext _context;

        public MatesController(MateContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Mates(string search)
        {
            var mates = from m in _context.Mate
                        select m;

            if (!String.IsNullOrEmpty(search))
            {
                mates = mates.Where(s => s.Name!.Contains(search));
            }

            return View(await mates.ToListAsync());
        }
        public async Task<IActionResult> Mates()
        {
            return View(await _context.Mate.ToListAsync());
        }

        //From:MS By Sech
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var mates = from m in _context.Mate
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                mates = mates.Where(s => s.Name!.Contains(search));
            }

            return View(await mates.ToListAsync());
        }

        // GET: Mates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mate.ToListAsync());
        }

        // GET: Mates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mate = await _context.Mate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mate == null)
            {
                return NotFound();
            }

            return View(mate);
        }

        // GET: Mates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDay,Title,ImgURL,Body,GrURL,ShowOn")] Mate mate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mate);
        }

        // GET: Mates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mate = await _context.Mate.FindAsync(id);
            if (mate == null)
            {
                return NotFound();
            }
            return View(mate);
        }

        // POST: Mates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDay,Title,ImgURL,Body,GrURL,ShowOn")] Mate mate)
        {
            if (id != mate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateExists(mate.Id))
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
            return View(mate);
        }

        // GET: Mates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mate = await _context.Mate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mate == null)
            {
                return NotFound();
            }

            return View(mate);
        }

        // POST: Mates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mate = await _context.Mate.FindAsync(id);
            _context.Mate.Remove(mate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateExists(int id)
        {
            return _context.Mate.Any(e => e.Id == id);
        }
    }
}
