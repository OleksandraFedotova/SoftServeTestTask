using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.Data;
using SoftServeTestTask.Models;
using Microsoft.AspNetCore.Authorization;

namespace SoftServeTestTask.Controllers
{
    [Authorize]
    public class OfferingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfferingsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Offerings
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Offerings.Include(o => o.Family);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Offerings/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offering = await _context.Offerings
                .Include(o => o.Family)
                .SingleOrDefaultAsync(m => m.OfferingId == id);
            if (offering == null)
            {
                return NotFound();
            }

            return View(offering);
        }

        // GET: Offerings/Create
        public IActionResult Create()
        {
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId");
            return View();
        }

        // POST: Offerings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfferingId,OfferingDescr,FamilyId")] Offering offering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offering);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", offering.FamilyId);
            return View(offering);
        }

        // GET: Offerings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offering = await _context.Offerings.SingleOrDefaultAsync(m => m.OfferingId == id);
            if (offering == null)
            {
                return NotFound();
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", offering.FamilyId);
            return View(offering);
        }

        // POST: Offerings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfferingId,OfferingDescr,FamilyId")] Offering offering)
        {
            if (id != offering.OfferingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferingExists(offering.OfferingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", offering.FamilyId);
            return View(offering);
        }

        // GET: Offerings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offering = await _context.Offerings
                .Include(o => o.Family)
                .SingleOrDefaultAsync(m => m.OfferingId == id);
            if (offering == null)
            {
                return NotFound();
            }

            return View(offering);
        }

        // POST: Offerings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offering = await _context.Offerings.SingleOrDefaultAsync(m => m.OfferingId == id);
            _context.Offerings.Remove(offering);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OfferingExists(int id)
        {
            return _context.Offerings.Any(e => e.OfferingId == id);
        }
    }
}
