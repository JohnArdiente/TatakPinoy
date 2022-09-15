using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        [JsonIgnore]
        public ICollection<Consignee> Consignees { get; set; }
    }
}
