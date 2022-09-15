using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TatakPinoy.Models;

namespace TatakPinoy.Data
{
    public class TatakPinoyContext : DbContext
    {
        public TatakPinoyContext (DbContextOptions<TatakPinoyContext> options)
            : base(options)
        {
        }

        public DbSet<TatakPinoy.Models.Shipment> Shipment { get; set; }
    }
}
