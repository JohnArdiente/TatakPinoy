using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TatakPinoy.Data;

namespace TatakPinoy.Controllers
{
    public class ReportsController : Controller
    {
        private readonly TatakPinoyContext _TatakContext;

        public ReportsController(TatakPinoyContext TatakContext)
        {
            _TatakContext = TatakContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Export(string shipment_no)
        {


            DataTable dt = new DataTable("Saob Report");
            using (XLWorkbook wb = new XLWorkbook())
            {

                var result = (from s in _TatakContext.Shipment
                              join c in _TatakContext.Consignee
                              on s.ShipmentId equals c.ShipmentId
                              where s.ShipmentNo == shipment_no
                              select new
                              {
                                  shipmentNo = s.ShipmentNo,
                                  trackingNo = c.TrackingNo,
                                  sender = c.ShipersName,
                                  senderNo = c.ShipersNo,
                                  consigneeName = c.ConsigneesName,
                                  consigneeAddress = c.ConsigneesAddr,
                                  consigneeNo = c.ConsigneesNo,
                                  qty = c.Qty,
                                  agent = c.AgentsName

                              }).ToList();


                var ws = wb.Worksheets.Add(dt);

                ws.Cell("A1").Style.Font.FontSize = 10;
                ws.Cell("A1").Style.Font.FontName = "Calibri Light";
                ws.Cell("A1").Value = "Shipment Number";
                ws.Columns(1, 2).Width = 15;

                ws.Cell("B1").Style.Font.FontSize = 10;
                ws.Cell("B1").Style.Font.FontName = "Calibri Light";
                ws.Cell("B1").Value = result.FirstOrDefault().shipmentNo;






                //ws.Columns().AdjustToContents();
                //ws.Rows().AdjustToContents();
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    ws.Rows().AdjustToContents();
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports" + ".xlsx");
                }
            }
        }
    }
}
