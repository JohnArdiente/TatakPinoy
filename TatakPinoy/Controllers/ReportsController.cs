using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TatakPinoy.Data;
using TatakPinoy.Models;

namespace TatakPinoy.Controllers
{
    [Authorize]
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


            DataTable dt = new DataTable("Reports");
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
                                  containerNo = s.ContainerNo,
                                  sender = c.ShipersName,
                                  senderNo = c.ShipersNo,
                                  consigneeName = c.ConsigneesName,
                                  consigneeAddress = c.ConsigneesAddr,
                                  consigneeNo = c.ConsigneesNo,
                                  qty = c.Qty,
                                  agent = c.AgentsName

                              }).ToList();

                var shipments = _TatakContext.Shipment.Include(x => x.Consignees).Where(x=>x.ShipmentNo == shipment_no).ToList();

                ViewBag.shipmentNo = shipment_no;
                if (shipments.Count == 0)
                {
                    ViewBag.shipments = "Shipment Not Found";
                    return View("Views/Reports/Index.cshtml", shipments);
                }

                var currentRow = 8;

                var ws = wb.Worksheets.Add(dt);

                ws.Cell("A1").Style.Font.FontSize = 10;
                ws.Cell("A1").Style.Font.FontName = "Calibri Light";
                ws.Cell("A1").Value = "Shipment Number";
                ws.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Columns(1, 2).Width = 15;

                ws.Cell("B1").Style.Font.FontSize = 10;
                ws.Cell("B1").Style.Font.FontName = "Calibri Light";
                ws.Cell("B1").Value = shipments.FirstOrDefault().ShipmentNo;
                ws.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                ws.Cell("A2").Style.Font.FontSize = 10;
                ws.Cell("A2").Style.Font.FontName = "Calibri Light";
                ws.Cell("A2").Value = "Container Number";
                ws.Cell("A2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Columns(1, 2).Width = 15;

                ws.Cell("B2").Style.Font.FontSize = 10;
                ws.Cell("B2").Style.Font.FontName = "Calibri Light";
                ws.Cell("B2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("B2").Value = shipments.FirstOrDefault().ContainerNo;



                //HEADERS

                ws.Cell("A7").Style.Font.FontSize = 10;
                ws.Cell("A7").Style.Font.FontName = "Calibri Light";
                ws.Cell("A7").Value = "Tracking Number";
                ws.Cell("A7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("A7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("B7").Style.Font.FontSize = 10;
                ws.Cell("B7").Style.Font.FontName = "Calibri Light";
                ws.Cell("B7").Value = "Shipper's Name";
                ws.Cell("B7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("B7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("C7").Style.Font.FontSize = 10;
                ws.Cell("C7").Style.Font.FontName = "Calibri Light";
                ws.Cell("C7").Value = "Shipper's CTC";
                ws.Cell("C7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("C7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("D7").Style.Font.FontSize = 10;
                ws.Cell("D7").Style.Font.FontName = "Calibri Light";
                ws.Cell("D7").Value = "Consignee";
                ws.Cell("D7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("D7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("E7").Style.Font.FontSize = 10;
                ws.Cell("E7").Style.Font.FontName = "Calibri Light";
                ws.Cell("E7").Value = "Consignee's Address";
                ws.Cell("E7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("E7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("F7").Style.Font.FontSize = 10;
                ws.Cell("F7").Style.Font.FontName = "Calibri Light";
                ws.Cell("F7").Value = "Consingee's CTC";
                ws.Cell("F7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("F7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("G7").Style.Font.FontSize = 10;
                ws.Cell("G7").Style.Font.FontName = "Calibri Light";
                ws.Cell("G7").Value = "Agent";
                ws.Cell("G7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("G7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("H7").Style.Font.FontSize = 10;
                ws.Cell("H7").Style.Font.FontName = "Calibri Light";
                ws.Cell("H7").Value = "Pick-up Date";
                ws.Cell("H7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("H7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                ws.Cell("I7").Style.Font.FontSize = 10;
                ws.Cell("I7").Style.Font.FontName = "Calibri Light";
                ws.Cell("I7").Value = "QTY";
                ws.Cell("I7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                ws.Cell("I7").Style.Font.SetBold();
                ws.Columns(1, 2).Width = 25;

                foreach (Shipment shipment in shipments)
                    {
                        foreach (var consignee in shipment.Consignees.ToList())
                        {

                            ws.Cell(currentRow, 1).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 1).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 1).Value = consignee.TrackingNo;
                            ws.Cell(currentRow, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 2).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 2).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 2).Value = consignee.ShipersName.ToUpper();
                            ws.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            

                            ws.Cell(currentRow, 3).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 3).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 3).Value = consignee.ShipersNo;
                            ws.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 4).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 4).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 4).Value = consignee.ConsigneesName;
                            ws.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 5).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 5).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 5).Value = consignee.ConsigneesAddr;
                            ws.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 6).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 6).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 6).Value = consignee.ConsigneesNo;
                            ws.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 7).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 7).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 7).Value = consignee.AgentsName;
                            ws.Cell(currentRow, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 8).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 8).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 8).Value = consignee.PickupDate;
                            ws.Cell(currentRow, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell(currentRow, 9).Style.Font.FontSize = 10;
                            ws.Cell(currentRow, 9).Style.Font.FontName = "Calibri Light";
                            ws.Cell(currentRow, 9).Value = consignee.Qty;
                            ws.Cell(currentRow, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            currentRow++;
                        }
                    }


                ws.Columns().AdjustToContents();
                ws.Rows().AdjustToContents();
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    ws.Rows().AdjustToContents();
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Shipment" + " " + shipment_no + "Manifest Report" + ".xlsx");
                }
            }
        }
    }
}
