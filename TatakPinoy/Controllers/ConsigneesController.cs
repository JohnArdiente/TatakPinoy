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
        public async Task<IActionResult> Index(int shipmentid, string searchString)
        {
            ViewBag.ShipmentId = shipmentid;
            var tatakPinoyContext = _context.Consignee.Include(x=>x.Shipment).Include(x=>x.ConsigneeStatus).Where(x=>x.ShipmentId == shipmentid);


            return View(await tatakPinoyContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var consignees = from s in _context.Consignee.Include(x => x.Shipment) select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                consignees = consignees.Where(x => x.TrackingNo!.Contains(searchString));
            }

            return View(await consignees.Include(x=>x.ConsigneeStatus).ToListAsync());
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
        public IActionResult Create(int shipmentId)
        {
            return View(new Consignee() { ShipmentId = shipmentId });
        }

        // POST: Consignees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsigneeId,TrackingNo,ShipersName,ShipersNo,ConsigneesName,ConsigneesAddr,ConsigneesNo,Qty,AgentsName,PickupDate,ShipmentId")] Consignee consignee)
        {
            if (ModelState.IsValid)
            {
                consignee.ConsigneeStatusId = 1;
                _context.Add(consignee);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", new { shipmentid = consignee.ShipmentId });
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

            var consignee = await _context.Consignee
                .Include(x => x.ConsigneeStatus)
                .FirstOrDefaultAsync(x => x.ConsigneeId == id);
            if (consignee == null)
            {
                return NotFound();
            }
            PopulateConsigneeStatusDropDownList(consignee.ConsigneeStatusId??0);
            return View(consignee);
        }

        // POST: Consignees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Consignee model)
        {
            if (model.ConsigneeId == 0) return NotFound();

            if (ModelState.IsValid)
            {
                var consignee = await _context.Consignee
                    .Include(x => x.ConsigneeStatus)
                    .Include(x => x.ConsigneeStatusHistories)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ConsigneeId == model.ConsigneeId);

                if ((consignee.ConsigneeStatusId != model.ConsigneeStatusId) && model.ConsigneeStatusId != null)
                {
                    var newHistory = new ConsigneeStatusHistory()
                    {
                        ConsigneeId = consignee.ConsigneeId,
                        ConsigneeStatusId = model.ConsigneeStatusId.Value,
                        UpdatedAt = DateTime.Now
                    };
                    if (consignee.ConsigneeStatusHistories != null)
                    {
                        consignee.ConsigneeStatusHistories = new List<ConsigneeStatusHistory> { newHistory };
                    }
                    else
                    {
                        consignee.ConsigneeStatusHistories.Add(newHistory);
                    }
                }
                model.ConsigneeStatusHistories = consignee.ConsigneeStatusHistories;
                _context.Update(model);
                await _context.SaveChangesAsync();
                PopulateConsigneeStatusDropDownList(model.ConsigneeStatusId);
                return View(consignee);
            }
            /*if (id == null)
            {
                return NotFound();
            }

            var consigneeToUpdate = await _context.Consignee
                .FirstOrDefaultAsync(c => c.ConsigneeId == id);

            if (await TryUpdateModelAsync<Consignee>(consigneeToUpdate,
                "",
                c => c.TrackingNo, c => c.ConsigneeStatusId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException *//* ex *//*)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Index", new { shipmentid = consigneeToUpdate.ShipmentId });
            }*/

            return View(model);
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
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", new { shipmentid = consignee.ShipmentId });
        }

        private bool ConsigneeExists(int id)
        {
            return _context.Consignee.Any(e => e.ConsigneeId == id);
        }
        private void PopulateConsigneeStatusDropDownList(int? selectedStatus = null)
        {
            var statusQuery = _context.ConsigneeStatus.OrderBy(x => x.Id).AsNoTracking().ToList();
            Console.WriteLine(statusQuery.Count);
            ViewBag.ConsigneeStatusId = new SelectList(statusQuery, "Id", "ConsigneeStatusDesc", selectedStatus);
        }
    }
}
