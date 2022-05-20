using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NoteMaker.API.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using System.Text;

namespace NoteMaker.API.DAL
{
    public class NoteContext : DbContext
    {
        public DbSet<NoteModel> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DBConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteModel>().ToTable("Notes");
            modelBuilder.Entity<NoteModel>().Property(n => n.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<NoteModel>().HasKey(n => n.ID);
        }
    }
}
