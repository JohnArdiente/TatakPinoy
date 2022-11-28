using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Barcode { get; set; }

        public string Destination { get; set; }
        [Display(Name = "Regular")]
        public int RegularQuantity { get; set; }
        [Display(Name = "Jumbo")]
        public int JumboQuantity { get; set; }
        [Display(Name = "Irregular")]
        public int IrregularQuantity { get; set; }
        public string Others { get; set; }
        [Display(Name = "Specify:")]
        public string SpecifyOthers { get; set; }

        public string BoxType { get; set; }
        public int Qty { get; set; }
        public string AgentsName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime PickupDate { get; set; }
        public string? RecievedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DeliveryDate { get; set; }
        public string? BackloadReason { get; set; }

        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public int? ConsigneeStatusId { get; set; }
        public virtual ConsigneeStatus ConsigneeStatus { get; set; }
        public ICollection<ConsigneeStatusHistory> ConsigneeStatusHistories { get; set; }
        [Display(Name = "Date")]
        public DateTime? TrackingStatusDate { get; set; }
    }
}
