﻿using CarDealers.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.DataManager.Context
{
    public class CarDealerDbContext : IdentityDbContext
    {
        public CarDealerDbContext(DbContextOptions option) : base(option)
        {

        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Advertistment> Advertistment { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Modal> Modal { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<UserComments> UserComment { get; set; }

        public DbSet<FavouriteAdvertistment> FavouriteAdvertistment { get; set; }

        public DbSet<ReportedAdvertisment> ReportedAdvertisment { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    //string sqlConnectionString = "Server=DESKTOP-AN6SANN; Database=CarDealersDb; Trusted_Connection=True";
        //    string sqlConnectionString = "Server=DESKTOP-7UFK8SA\\SQL2016; Database=CarDealersDbSec;Integrated Security=SSPI; User ID = sa ;Password=welcome@123";
        //    builder.UseSqlServer(sqlConnectionString);
        //    base.OnConfiguring(builder);
        //}
    }
}
