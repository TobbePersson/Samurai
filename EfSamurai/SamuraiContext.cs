using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EfSamurai.Domain;

namespace EfSamurai.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteType> QuoteTypes { get; set; }
        public DbSet<HairCut> HairCuts { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }
        public DbSet<BattleLog> BattleLogs { get; set; }
        public DbSet<BattleEvent> BattleEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = EfSamurai;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(x => new { x.SamuraiId, x.BattleId });

            modelBuilder.Entity<Battle>()
                .HasOne(a => a.BattleLog).WithOne(b => b.Battle).HasForeignKey<BattleLog>(b => b.Id);
            base.OnModelCreating(modelBuilder);
        }



    }
}
