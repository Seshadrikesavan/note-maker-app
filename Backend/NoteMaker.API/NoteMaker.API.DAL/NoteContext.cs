using Microsoft.EntityFrameworkCore;
using NoteMaker.API.Model;
using NoteMaker.API.Utility;
using System;
using System.Collections.Generic;
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
                string connectionString = ConfigHelper.GetConnectionString("DBConnectionString");
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
