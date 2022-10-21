using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TatakPinoy.Data;
using TatakPinoy.Models;

namespace TatakPinoy.Controllers
{
    [Authorize]
    public class ShipmentsController : Controller
    {
        
        private readonly TatakPinoyContext _context;

        public ShipmentsController(TatakPinoyContext context)
        {
            _context = context;
        }

        // GET: Shipments
        public async Task<IActionResult> Index(string searchString)
        {
            var shipments = from m in _context.Shipment
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                shipments = shipments.Where(s => s.ShipmentNo!.Contains(searchString));
            }


            return View(await shipments.Include(x=>x.Status).Include(x=>x.Consignees).ToListAsync());
        }

        // GET: Shipments
        public async Task<IActionResult> Update(string searchString)
        {
            var shipments = from m in _context.Shipment
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                shipments = shipments.Where(s => s.ShipmentNo!.Contains(searchString));
            }

            return View(await shipments.Include(x => x.ShipmentStatusHistory).ToListAsync());
        }

        // GET: Shipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .FirstOrDefaultAsync(m => m.ShipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // GET: Shipments/Create
        public IActionResult Create()
        {
            PopulateStatusDropDownList();
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipmentId,ShipmentNo,ContainerNo")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                /*shipment.StatusId = 1;*/
                shipment.CreatedAt = DateTime.Now;
                _context.Add(shipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipment);
        }

        public JsonResult CheckifExist(string userdata)
        {
            var data = _context.Shipment.Where(x => x.ShipmentNo == userdata).SingleOrDefault();

            if (data != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        // GET: Shipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .Include(x => x.Status).ThenInclude(x=>x.ShipmentStatusHistory)
                .FirstOrDefaultAsync(x => x.ShipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }
            PopulateStatusDropDownList(shipment.StatusId??0);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Shipment model)
        {
            if (model.ShipmentId == 0) return NotFound();

            if (ModelState.IsValid)
            {
                var shipment = await _context.Shipment
                    .Include(x => x.Status)
                    .Include(x => x.ShipmentStatusHistory)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ShipmentId == model.ShipmentId);

                if ((shipment.StatusId != model.StatusId) && model.StatusId != null)
                {
                    model.DateOn = new DateTime();
                    var date = model?.DateOn;
                    var newHistory = new ShipmentStatusHistory()
                    {
                        ShipmentId = shipment.ShipmentId,
                        StatusId = model.StatusId.Value,
                        UpdatedAt = DateTime.Now,
                        DateOn = date
                    };
                    if (shipment.ShipmentStatusHistory != null)
                    {
                        shipment.ShipmentStatusHistory = new List<ShipmentStatusHistory> { newHistory };
                    }
                    else
                    {
                        shipment.ShipmentStatusHistory.Add(newHistory);
                    }
                }
                model.ShipmentStatusHistory = shipment.ShipmentStatusHistory;
                _context.Update(model);
                await _context.SaveChangesAsync();
                PopulateStatusDropDownList(model.StatusId);
                return RedirectToAction("Update", "Shipments");
            }
            return View(model);
        }

        // GET: Shipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .FirstOrDefaultAsync(m => m.ShipmentId == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipment = await _context.Shipment.FindAsync(id);
            _context.Shipment.Remove(shipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipment.Any(e => e.ShipmentId == id);
        }

        private void PopulateStatusDropDownList(object selectedStatus = null)
        {
            var statusQuery = from d in _context.Status
                                   orderby d.StatusId
                                   select d;
            ViewBag.StatusId = new SelectList(statusQuery, "StatusId", "StatusDesc", selectedStatus);
        }
    }
}
