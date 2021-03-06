﻿using SimpleVegan.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleVegan.DAL
{
    public class SimpleVeganContext : DbContext
    {
        public SimpleVeganContext() : base("SimpleVeganContext")
        { 
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<EventBooking> EventBookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}