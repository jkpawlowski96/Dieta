using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Db
{
    public class DataContext : DbContext
    {

        public DbSet<History> History { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        /// <summary>
        /// Konfiguracja
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //database connection string
            optionsBuilder.UseMySQL(@"server=sql.jkpawlowski.nazwa.pl;database=jkpawlowski_dieta;user=jkpawlowski_web;password=cHNXacnPr49ZGnf");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
