using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ex_03.Models;

namespace Ex_03.Controllers
{
    public class LogginController : Controller
    {
        private readonly LoginContext _context;

        public LogginController(LoginContext context)
        {
            _context = context;
        }

        // GET: Loggin
        public async Task<IActionResult> Index()
        {
            return View(await _context.DangNhap.ToListAsync());
        }

        // GET: Loggin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap
                .FirstOrDefaultAsync(m => m.Username == id);
            if (dangNhap == null)
            {
                return NotFound();
            }

            return View(dangNhap);
        }

        // GET: Loggin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loggin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password")] DangNhap dangNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangNhap);
        }

        // GET: Loggin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap.FindAsync(id);
            if (dangNhap == null)
            {
                return NotFound();
            }
            return View(dangNhap);
        }

        // POST: Loggin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password")] DangNhap dangNhap)
        {
            if (id != dangNhap.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangNhapExists(dangNhap.Username))
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
            return View(dangNhap);
        }

        // GET: Loggin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap
                .FirstOrDefaultAsync(m => m.Username == id);
            if (dangNhap == null)
            {
                return NotFound();
            }

            return View(dangNhap);
        }

        // POST: Loggin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dangNhap = await _context.DangNhap.FindAsync(id);
            _context.DangNhap.Remove(dangNhap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangNhapExists(string id)
        {
            return _context.DangNhap.Any(e => e.Username == id);
        }
    }
}
