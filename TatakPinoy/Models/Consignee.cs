using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Consignee
    {
        public int ConsigneeId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
