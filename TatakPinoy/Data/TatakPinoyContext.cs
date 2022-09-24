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

        public DbSet<TatakPinoy.Models.Consignee> Consignee { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<TatakPinoy.Models.Status> Status { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipment>()
                .HasOne(b => b.Status)
                .WithOne(i => i.Shipment)
                .HasForeignKey<Status>(b => b.ShipmentId);
        }*/

    }
}
