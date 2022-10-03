using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TatakPinoy.Data;
using TatakPinoy.Models;

namespace TatakPinoy.Controllers
{
    public class ConsigneeStatusController : Controller
    {
        private readonly TatakPinoyContext _context;

        public ConsigneeStatusController(TatakPinoyContext context)
        {
            _context = context;
        }

        // GET: ConsigneeStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsigneeStatus.ToListAsync());
        }

        // GET: ConsigneeStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           /* var consigneeStatus = await _context.ConsigneeStatus
                .FirstOrDefaultAsync(m => m.ConsigneeStatusId == id);
            if (consigneeStatus == null)
            {
                return NotFound();
            }*/

            return View();
        }

        // GET: ConsigneeStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsigneeStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsigneeStatusId,ConsigneeStatusDesc")] ConsigneeStatus consigneeStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consigneeStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consigneeStatus);
        }

        // GET: ConsigneeStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consigneeStatus = await _context.ConsigneeStatus.FindAsync(id);
            if (consigneeStatus == null)
            {
                return NotFound();
            }
            return View(consigneeStatus);
        }

        // POST: ConsigneeStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsigneeStatusId,ConsigneeStatusDesc")] ConsigneeStatus consigneeStatus)
        {
            /*if (id != consigneeStatus.ConsigneeStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consigneeStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsigneeStatusExists(consigneeStatus.ConsigneeStatusId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }*/
            return View();
        }

        // GET: ConsigneeStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var consigneeStatus = await _context.ConsigneeStatus
                .FirstOrDefaultAsync(m => m.ConsigneeStatusId == id);
            if (consigneeStatus == null)
            {
                return NotFound();
            }*/

            return View();
        }

        // POST: ConsigneeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consigneeStatus = await _context.ConsigneeStatus.FindAsync(id);
            _context.ConsigneeStatus.Remove(consigneeStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsigneeStatusExists(int id)
        {
            return true; // _context.ConsigneeStatus.Any(e => e.ConsigneeStatusId == id);
        }
    }
}
