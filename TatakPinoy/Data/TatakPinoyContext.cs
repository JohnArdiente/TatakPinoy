using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TatakPinoy.Models;

namespace TatakPinoy.Data
{
    public class TatakPinoyContext : IdentityDbContext
    {
        public TatakPinoyContext (DbContextOptions<TatakPinoyContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipment { get; set; }

        public DbSet<Consignee> Consignee { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<ConsigneeStatus> ConsigneeStatus { get; set; }

        public DbSet<ConsigneeStatusHistory> ConsigneeStatusHistories { get; set; }

        public DbSet<TatakPinoy.Models.Contact> Contact { get; set; }

        public DbSet<TatakPinoy.Models.Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Status>().HasData(
                    new Status { StatusId = 1, StatusDesc = "Select Status", ShipmentId = null },
                    new Status { StatusId = 2, StatusDesc = "EDA AT MANILA PORT IS", ShipmentId = null },
                    new Status { StatusId = 3, StatusDesc = "EDA AT CEBU PORT IS", ShipmentId = null },
                    new Status { StatusId = 4, StatusDesc = "VESSEL DELAYED NEW EDA IS", ShipmentId = null },
                    new Status { StatusId = 5, StatusDesc = "ARRIVED AT PHILIPPINE PORT", ShipmentId = null },
                    new Status { StatusId = 6, StatusDesc = "ONGOING CUSTOMS CLEARING", ShipmentId = null },
                    new Status { StatusId = 7, StatusDesc = "UNLOADED AT LOCAL WH", ShipmentId = null }
            );
            modelBuilder.Entity<ConsigneeStatus>().HasData(
                    new ConsigneeStatus { Id = 1, ConsigneeStatusDesc = "SCHEDULE FOR DELIVERY" },
                    new ConsigneeStatus { Id = 2, ConsigneeStatusDesc = "IN TRANSIT TO CEBU WH" },
                    new ConsigneeStatus { Id = 3, ConsigneeStatusDesc = "IN TRANSIT TO MANILA WH" },
                    new ConsigneeStatus { Id = 4, ConsigneeStatusDesc = "ONGOING DELIVERY " },
                    new ConsigneeStatus { Id = 5, ConsigneeStatusDesc = "BACKLOADED" },
                    new ConsigneeStatus { Id = 6, ConsigneeStatusDesc = "DELIVERED" }
            );


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        

    }
}
