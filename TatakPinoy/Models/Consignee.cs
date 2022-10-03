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
        public string ShipersNo { get; set; }
        public string ConsigneesName { get; set; }
        public string ConsigneesAddr { get; set; }
        public string ConsigneesNo { get; set; }
        public int Qty { get; set; }
        public string AgentsName { get; set; }
        public DateTime PickupDate { get; set; }

        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public int? ConsigneeStatusId { get; set; }
        public virtual ConsigneeStatus ConsigneeStatus { get; set; }
        public ICollection<ConsigneeStatusHistory> ConsigneeStatusHistories { get; set; }
    }
}
