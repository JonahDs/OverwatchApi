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
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>()
                .HasMany(p => p.Abilities).WithOne()
                .IsRequired()
                .HasForeignKey("HeroId");

            //Hero database structure
            modelBuilder.Entity<Hero>().HasKey(t => t.Id);
            modelBuilder.Entity<Hero>().Property(t => t.Name).HasMaxLength(50);
            modelBuilder.Entity<Hero>().Property(t => t.Role).HasMaxLength(30);
            modelBuilder.Entity<Hero>().Property(t => t.Health);
            modelBuilder.Entity<Hero>().Property(t => t.Shield);
            modelBuilder.Entity<Hero>().Property(t => t.HealingAmount);
            modelBuilder.Entity<Hero>().Property(t => t.Dps);
            modelBuilder.Entity<Hero>().HasMany(t => t.Abilities).WithOne();

            //Ability database structure
            modelBuilder.Entity<HeroAbilitie>().HasKey(t => t.Id);
            modelBuilder.Entity<HeroAbilitie>().Property(t => t.LeftClick);
            modelBuilder.Entity<HeroAbilitie>().Property(t => t.RightClick);
            modelBuilder.Entity<HeroAbilitie>().Property(t => t.MainAbilityOne);
            modelBuilder.Entity<HeroAbilitie>().Property(t => t.MainAbilityTwo);
            modelBuilder.Entity<HeroAbilitie>().Property(t => t.Ultimate);


            //Database seeding
            modelBuilder.Entity<Hero>().HasData(
                new Hero { Id = 1, Name = "Ana", Role = "Support", Dps = 70, HealingAmount = 75, Health = 200, Armour = 0, Shield = 0 },
                new Hero { Id = 2, Name = "Soldier:76", Role = "Dps", Dps = 200, HealingAmount = 0, Health = 200, Armour = 0, Shield = 0 }
                );

            //modelBuilder.Entity<HeroAbilitie>().HasData(
            //    new HeroAbilitie("Biotic Rifle", "Scoped Mode", "Sleep Dart", "Biotic Grenade", "Nano Boost"),
            //    new HeroAbilitie("Heavy Pulse Rifle", "Helix Rockets", "Sprint", "Biotic Field", "Tactical Visor")
            //    );

            modelBuilder.Entity<HeroAbilitie>().HasData(
                new { Id = 1, LeftClick = "Biotic Rifle", RightClick = "Scoped Mode", MainAbilityOne = "Sleep Dart", MainAbilityTwo = "Biotic Grenade", Ultimate = "Nano Boost", HeroId = 1 },
                new { Id = 2, LeftClick = "Heavy Pulse Rifle", RightClick = "Helix Rockets", MainAbilityOne = "Sprint", MainAbilityTwo = "Biotic Field", Ultimate = "Tactical Visor", HeroId = 2 }
                );


        }
        public DbSet<Hero> Heroes { get; set; }

    }
}
