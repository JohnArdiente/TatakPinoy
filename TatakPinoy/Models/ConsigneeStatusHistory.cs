using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public partial class ConsigneeStatusHistory
    {
        public int Id { get; set; }
        public int ConsigneeStatusId { get; set; }
        public virtual ConsigneeStatus ConsigneeStatus { get; set; }
        public int ConsigneeId { get; set; }
        public virtual Consignee Consignee { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? TrackingStatusDate { get; set; }
    }
}
