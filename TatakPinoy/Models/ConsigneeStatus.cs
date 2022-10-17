using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatakPinoy.Models
{
    public class ConsigneeStatus
    {
        public int Id { get; set; }
        public string? ConsigneeStatusDesc { get; set; }
        public ICollection<ConsigneeStatusHistory> ConsigneeStatusHistories { get; set; }
    }
}
