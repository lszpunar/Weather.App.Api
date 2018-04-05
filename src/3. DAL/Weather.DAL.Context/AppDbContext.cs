using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Weather.DAL.Models;

namespace Weather.DAL.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=dbMeasurments");
            //optionsBuilder.UseSqlServer(tenant.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


    }
}