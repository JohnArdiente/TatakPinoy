using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusDesc { get; set; }

        public Shipment Shipment { get; set; }
    }
}
