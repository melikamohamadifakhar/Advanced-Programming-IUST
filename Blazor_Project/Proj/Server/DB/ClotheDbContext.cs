using System;
using Microsoft.EntityFrameworkCore;
using P8.Server.Controllers;
using P8.Shared;

namespace P8.Server.DB
{
    public class ClotheDbContext : DbContext
    {
        public ClotheDbContext(DbContextOptions<ClotheDbContext> options)
        :base(options){
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
        public DbSet<Clothe> Clothes{get; set;}
    }
}