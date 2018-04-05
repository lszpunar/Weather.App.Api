using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Weather.DAL.Context;

namespace Weather.DAL.SQLiteContext
{
    public sealed class SQLiteAppDbContext : AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dbMeasurments");
            //optionsBuilder.UseSqlServer(tenant.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
