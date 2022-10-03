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

    }
}
