﻿using CMS.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<ComCost> comCosts { get; set; }
        public DbSet<Insurance> insurances { get; set; }
        public DbSet<Packaging> packagings { get; set; }
        public DbSet<VolDist> volDists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapTables(modelBuilder);
            SetDescriptionsAndDefaultValues(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void MapTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
        private void SetDescriptionsAndDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .Property(x => x.Id)
                 .HasComment("شناسه کاربر");
            modelBuilder.Entity<User>()
                 .Property(x => x.Name)
                 .HasComment("نام و نام خانوادگی");
            modelBuilder.Entity<User>()
                 .Property(x => x.Email)
                 .HasComment("ایمیل");
            modelBuilder.Entity<User>()
                 .Property(x => x.Phone)
                 .HasComment("شماره همراه");
            modelBuilder.Entity<User>()
                 .Property(x => x.Password)
                 .HasComment("کلمه عبور");
            modelBuilder.Entity<User>()
                 .Property(x => x.Address)
                 .HasComment("آدرس");
            //modelBuilder.Entity<WorkType>()
            //    .Property(x => x.IsActive)
            //    .HasComment("فعال")
            //    .HasDefaultValue(true);
            //modelBuilder.Entity<Work>()
            //    .HasOne(x => x.ImportanceLevel)
            //    .WithMany()
            //    .HasForeignKey(x => x.ImportanceLevelId);
        }
    }
}
