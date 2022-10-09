using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class ShipmentStatusHistory
    {
        public int Id { get; set; }
        public DateTime DateOn { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
