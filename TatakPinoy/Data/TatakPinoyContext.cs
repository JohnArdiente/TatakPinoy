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

        public DbSet<Shipment> Shipment { get; set; }

        public DbSet<Consignee> Consignee { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<ConsigneeStatus> ConsigneeStatus { get; set; }

        public DbSet<ConsigneeStatusHistory> ConsigneeStatusHistories { get; set; }

        public DbSet<TatakPinoy.Models.Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                    new Status { StatusId = 1, StatusDesc = "EDA AT MANILA PORT IS ON", ShipmentId = null },
                    new Status { StatusId = 2, StatusDesc = "ETA AT CEBU PORT IS ON", ShipmentId = null },
                    new Status { StatusId = 3, StatusDesc = "VESSEL DELAYED NEW EDA IS ON", ShipmentId = null },
                    new Status { StatusId = 4, StatusDesc = "ARRIVED AT PHILIPPINE PORT AND ONGOING CUSTOMS CLEARING", ShipmentId = null },
                    new Status { StatusId = 5, StatusDesc = "RELEASED FROM PHILIPPINE CUSTOMS", ShipmentId = null },
                    new Status { StatusId = 6, StatusDesc = "UNLOADED AT LOCAL WH", ShipmentId = null }
            );
            modelBuilder.Entity<ConsigneeStatus>().HasData(
                    new ConsigneeStatus { Id = 1, ConsigneeStatusDesc = "ARRIVED AT MANILA WH AND SCHEDULED FOR DELIVERY" },
                    new ConsigneeStatus { Id = 2, ConsigneeStatusDesc = "ARRIVED AT CEBU WH AND SCHEDULED FOR DELIVERY " },
                    new ConsigneeStatus { Id = 3, ConsigneeStatusDesc = "IN TRANSIT TO CEBU WH" },
                    new ConsigneeStatus { Id = 4, ConsigneeStatusDesc = "IN TRANSIT TO MANILA WH" },
                    new ConsigneeStatus { Id = 5, ConsigneeStatusDesc = "ONGOING DELIVERY " },
                    new ConsigneeStatus { Id = 6, ConsigneeStatusDesc = "BACKLOADED (REASON/EXCEPTION)" },
                    new ConsigneeStatus { Id = 7, ConsigneeStatusDesc = "DELIVERED" }
            );
        }

        public DbSet<TatakPinoy.Models.Message> Message { get; set; }

    }
}
