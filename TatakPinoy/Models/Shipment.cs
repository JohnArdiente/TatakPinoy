using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public string ShipmentNo { get; set; }

        [Display(Name ="Date")]
        public DateTime DateOn { get; set; }

        public ICollection<Consignee> Consignees { get; set; }

        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public ICollection<ShipmentStatusHistory> ShipmentStatusHistory { get; set; }
    }
}
