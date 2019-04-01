using Microsoft.EntityFrameworkCore;
using OverwatchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>()
                .HasMany(p => p.Properties).WithOne()
                .IsRequired()
                .HasForeignKey("HeroId");

                

            //Hero database structure
            //modelBuilder.Entity<Hero>().HasKey(t => t.Id);
            //modelBuilder.Entity<Hero>().Property(t => t.Name).HasMaxLength(50);
            //modelBuilder.Entity<Hero>().Property(t => t.Role).HasMaxLength(30);
            //modelBuilder.Entity<Hero>().Property(t => t.Health);
            //modelBuilder.Entity<Hero>().Property(t => t.Shield);
            //modelBuilder.Entity<Hero>().Property(t => t.CanHeal);
            //modelBuilder.Entity<Hero>().HasMany(t => t.Properties).WithOne();

            //

            //HeroProperty database structure



            //Database seeding
            modelBuilder.Entity<Hero>().HasData(
                new Hero { Id = 1, Name = "Ana", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 2, Name = "Soldier:76", Role = "Dps", CanHeal = true, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 3, Name = "Bastion", Role = "Dps", CanHeal = true, Health = 200, Armour = 100, Shield = 0 },
                new Hero { Id = 4, Name = "Brigitte", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 50 },
                new Hero { Id = 5, Name = "D.Va", Role = "Tank", CanHeal = false, Health = 400, Armour = 200, Shield = 0 },
                new Hero { Id = 6, Name = "Doomfist", Role = "Dps", CanHeal = false, Health = 250, Armour = 0, Shield = 0 },
                new Hero { Id = 7, Name = "Genji", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 8, Name = "Hanzo", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 9, Name = "Junkrat", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 10, Name = "Lucio", Role = "Support", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 11, Name = "McCree", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 12, Name = "Mei", Role = "Dps", CanHeal = true, Health = 250, Armour = 0, Shield = 0 },
                new Hero { Id = 13, Name = "Mercy", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 14, Name = "Moira", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 15, Name = "Orisa", Role = "Tank", CanHeal = false, Health = 200, Armour = 200, Shield = 0 },
                new Hero { Id = 16, Name = "Phara", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 17, Name = "Reaper", Role = "Dps", CanHeal = true, Health = 250, Armour = 0, Shield = 0 },
                new Hero { Id = 18, Name = "Reinhardt", Role = "Tank", CanHeal = false, Health = 300, Armour = 200, Shield = 0 },
                new Hero { Id = 19, Name = "Sombra", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 20, Name = "Symmetra", Role = "Dps", CanHeal = false, Health = 100, Armour = 0, Shield = 100 },
                new Hero { Id = 21, Name = "Torbjorn", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 22, Name = "Tracer", Role = "Dps", CanHeal = false, Health = 150, Armour = 0, Shield = 0 },
                new Hero { Id = 23, Name = "Widowmaker", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 24, Name = "Winston", Role = "Tank", CanHeal = false, Health = 400, Armour = 100, Shield = 0 },
                new Hero { Id = 25, Name = "Zarya", Role = "Tank", CanHeal = false, Health = 200, Armour = 0, Shield = 200 },
                new Hero { Id = 26, Name = "Zenyatta", Role = "Support", CanHeal = true, Health = 50, Armour = 0, Shield = 150 },
                new Hero { Id = 27, Name = "Ashe", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 28, Name = "Baptiste", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0 }
                );
        }

    }
}
