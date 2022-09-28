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

        public ICollection<Consignee> Consignees { get; set; }

        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
    }
}
