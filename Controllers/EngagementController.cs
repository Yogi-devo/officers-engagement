using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OfficerEngagement.Models;


namespace OfficerEngagement.Controllers
{
    //[Authorize]
    //[OutputCache(NoStore = true, Duratio = 0, VaryByParam = "None")]
    public class EngagementController : Controller
    {
        private readonly EngagementContext _context;

        public EngagementController(EngagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Engagement> CurentEng { get; set; }

        // GET: Engagement
        
        public async Task<IActionResult> Index()
        {
            CurentEng = await (from x in _context.Engagements where x.Date >= DateTime.Today select x).ToListAsync();
            return View(CurentEng);
            //return View(await _context.Engagements.ToListAsync());
        }


        //public async Task<ActionResult> EngagementHistory()
        //{
          
        //    return View(Engagements);

        //}

        public IEnumerable<Engagement> Engagements { get; set; }
        public async Task<IActionResult> EngagementHistory()
        {
            //Engagements = _context.Engagements.ToList();
            return View(await _context.Engagements.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> EngagementHistory(DateTime StartDate, DateTime EndDate)
        {
            Engagements = await (from x in _context.Engagements where (x.Date >= StartDate) && (x.Date <= EndDate) select x).ToListAsync();
            return View(Engagements);
        }


        // GET: Engagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engagement = await _context.Engagements
                .FirstOrDefaultAsync(m => m.EngId == id);
            if (engagement == null)
            {
                return NotFound();
            }

            return View(engagement);
        }

        // GET: Engagement/Create
        [Authorize]
        public IActionResult AddOrEdit(int id=0)
        {
            return View(new Engagement());
        }

        // POST: Engagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngId,OfficerName,Date,Time,Venue,ChairBy,Agenda,Status")] Engagement engagement)
        {

            if (ModelState.IsValid)
            {
                _context.Add(engagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engagement);
        }

        // GET: Engagement/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engagement = await _context.Engagements.FindAsync(id);
            if (engagement == null)
            {
                return NotFound();
            }
            return View(engagement);
        }

        // POST: Engagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngId,OfficerName,Date,Time,Venue,ChairBy,Agenda,Status")] Engagement engagement)
        {
            if (id != engagement.EngId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngagementExists(engagement.EngId))
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
            return View(engagement);
        }

        // GET: Engagement/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engagement = await _context.Engagements
                .FirstOrDefaultAsync(m => m.EngId == id);
            if (engagement == null)
            {
                return NotFound();
            }

            return View(engagement);
        }

        // POST: Engagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engagement = await _context.Engagements.FindAsync(id);
            _context.Engagements.Remove(engagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngagementExists(int id)
        {
            return _context.Engagements.Any(e => e.EngId == id);
        }


       
        
    }
}
