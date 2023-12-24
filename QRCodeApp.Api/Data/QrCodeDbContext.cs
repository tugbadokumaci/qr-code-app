using System;
using Microsoft.EntityFrameworkCore;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Api.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CardModel> Cards { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CardModel>()
        //        .HasOne(c => c.CardOwner)
        //        .WithMany(u => u.Cards)
        //        .HasForeignKey(c => c.CardOwnerId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }

}

