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
    public class ConsigneesController : Controller
    {
        private readonly TatakPinoyContext _context;

        public ConsigneesController(TatakPinoyContext context)
        {
            _context = context;
        }

        // GET: Consignees
        public async Task<IActionResult> Index()
        {
            var tatakPinoyContext = _context.Consignee.Include(c => c.Shipment);
            return View(await tatakPinoyContext.ToListAsync());
        }

        // GET: Consignees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignee = await _context.Consignee
                .Include(c => c.Shipment)
                .FirstOrDefaultAsync(m => m.ConsigneeId == id);
            if (consignee == null)
            {
                return NotFound();
            }

            return View(consignee);
        }

        // GET: Consignees/Create
        public IActionResult Create()
        {
            ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId");
            return View();
        }

        // POST: Consignees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsigneeId,Fname,Mname,Lname,Address,ContactNo,ShipmentId")] Consignee consignee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consignee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", consignee.ShipmentId);
            return View(consignee);
        }

        // GET: Consignees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignee = await _context.Consignee.FindAsync(id);
            if (consignee == null)
            {
                return NotFound();
            }
            ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", consignee.ShipmentId);
            return View(consignee);
        }

        // POST: Consignees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsigneeId,Fname,Mname,Lname,Address,ContactNo,ShipmentId")] Consignee consignee)
        {
            if (id != consignee.ConsigneeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consignee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsigneeExists(consignee.ConsigneeId))
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
            ViewData["ShipmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", consignee.ShipmentId);
            return View(consignee);
        }

        // GET: Consignees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignee = await _context.Consignee
                .Include(c => c.Shipment)
                .FirstOrDefaultAsync(m => m.ConsigneeId == id);
            if (consignee == null)
            {
                return NotFound();
            }

            return View(consignee);
        }

        // POST: Consignees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consignee = await _context.Consignee.FindAsync(id);
            _context.Consignee.Remove(consignee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsigneeExists(int id)
        {
            return _context.Consignee.Any(e => e.ConsigneeId == id);
        }
    }
}
