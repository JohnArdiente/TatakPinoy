using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }
}
