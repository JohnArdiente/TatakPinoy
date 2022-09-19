using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Consignee
    {
        public int ConsigneeId { get; set; }
        public string TrackingNo { get; set; }
        public string ShipersName { get; set; }
        public int ShipersNo { get; set; }
        public string ConsigneesName { get; set; }
        public string ConsigneesAddr { get; set; }
        public int ConsigneesNo { get; set; }
        public int Qty { get; set; }
        public string AgentsName { get; set; }
        public DateTime PickupDate { get; set; }

        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
