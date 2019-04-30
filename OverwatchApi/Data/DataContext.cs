using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OverwatchApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<TeamComp> TeamComp { get; set;
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Hero structure
            modelBuilder.Entity<Hero>()
                .HasMany(p => p.Properties).WithOne()
                .IsRequired()
                .HasForeignKey("HeroId");

            //HeroProperty  structure
            modelBuilder.Entity<HeroProperties>()
               .HasKey(t => t.Id);

            //User structure
            modelBuilder.Entity<User>()
                .HasKey(t => t.Username);

            //HeroTeamComp structure
            modelBuilder.Entity<HeroTeamComp>()
                .HasKey(t => new { t.HeroId, t.TeamCompId });
            modelBuilder.Entity<HeroTeamComp>()
                .HasOne(t => t.Hero)
                .WithMany(t => t.TeamComps)
                .HasForeignKey(t => t.HeroId);
            modelBuilder.Entity<HeroTeamComp>()
                .HasOne(t => t.TeamComp)
                .WithMany(t => t.TeamCompHeroes)
                .HasForeignKey(t => t.TeamCompId);


            //Database seeding
            #region Seeding
            modelBuilder.Entity<Hero>().HasData(
                new Hero { Id = 1, Name = "Ana", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0 , Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/ana/hero-select-portrait.png" },
                new Hero { Id = 2, Name = "Soldier:76", Role = "Dps", CanHeal = true, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/soldier-76/hero-select-portrait.png" },
                new Hero { Id = 3, Name = "Bastion", Role = "Dps", CanHeal = true, Health = 200, Armour = 100, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/bastion/hero-select-portrait.png" },
                new Hero { Id = 4, Name = "Brigitte", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 50, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/brigitte/hero-select-portrait.png" },
                new Hero { Id = 5, Name = "D.Va", Role = "Tank", CanHeal = false, Health = 400, Armour = 200, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/dva/hero-select-portrait.png" },
                new Hero { Id = 6, Name = "Doomfist", Role = "Dps", CanHeal = false, Health = 250, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/doomfist/hero-select-portrait.png" },
                new Hero { Id = 7, Name = "Genji", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/genji/hero-select-portrait.png" },
                new Hero { Id = 8, Name = "Hanzo", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/hanzo/hero-select-portrait.png" },
                new Hero { Id = 9, Name = "Junkrat", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/junkrat/hero-select-portrait.png" },
                new Hero { Id = 10, Name = "Lucio", Role = "Support", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/lucio/hero-select-portrait.png" },
                new Hero { Id = 11, Name = "McCree", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/mccree/hero-select-portrait.png" },
                new Hero { Id = 12, Name = "Mei", Role = "Dps", CanHeal = true, Health = 250, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/mei/hero-select-portrait.png" },
                new Hero { Id = 13, Name = "Mercy", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/mercy/hero-select-portrait.png" },
                new Hero { Id = 14, Name = "Moira", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/moira/hero-select-portrait.png" },
                new Hero { Id = 15, Name = "Orisa", Role = "Tank", CanHeal = false, Health = 200, Armour = 200, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/orisa/hero-select-portrait.png" },
                new Hero { Id = 16, Name = "Pharah", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/pharah/hero-select-portrait.png" },
                new Hero { Id = 17, Name = "Reaper", Role = "Dps", CanHeal = true, Health = 250, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/reaper/hero-select-portrait.png" },
                new Hero { Id = 18, Name = "Reinhardt", Role = "Tank", CanHeal = false, Health = 300, Armour = 200, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/reinhardt/hero-select-portrait.png" },
                new Hero { Id = 19, Name = "Sombra", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/sombra/hero-select-portrait.png" },
                new Hero { Id = 20, Name = "Symmetra", Role = "Dps", CanHeal = false, Health = 100, Armour = 0, Shield = 100, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/symmetra/hero-select-portrait.png" },
                new Hero { Id = 21, Name = "Torbjörn", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/torbjorn/hero-select-portrait.png" },
                new Hero { Id = 22, Name = "Tracer", Role = "Dps", CanHeal = false, Health = 150, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/tracer/hero-select-portrait.png" },
                new Hero { Id = 23, Name = "Widowmaker", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/widowmaker/hero-select-portrait.png" },
                new Hero { Id = 24, Name = "Winston", Role = "Tank", CanHeal = false, Health = 400, Armour = 100, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/winston/hero-select-portrait.png" },
                new Hero { Id = 25, Name = "Zarya", Role = "Tank", CanHeal = false, Health = 200, Armour = 0, Shield = 200, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/zarya/hero-select-portrait.png" },
                new Hero { Id = 26, Name = "Zenyatta", Role = "Support", CanHeal = true, Health = 50, Armour = 0, Shield = 150, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/zenyatta/hero-select-portrait.png" },
                new Hero { Id = 27, Name = "Ashe", Role = "Dps", CanHeal = false, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/ashe/hero-select-portrait.png" },
                new Hero { Id = 28, Name = "Baptiste", Role = "Support", CanHeal = true, Health = 200, Armour = 0, Shield = 0, Image= "https://d1u1mce87gyfbn.cloudfront.net/hero/baptiste/hero-select-portrait.png" },
                new Hero { Id = 29, Name = "Wrecking Ball", Role = "Tank", CanHeal = false, Health = 500, Armour = 100, Shield = 0, Image = "https://d1u1mce87gyfbn.cloudfront.net/hero/wrecking-ball/hero-select-portrait.png" }

                );


            modelBuilder.Entity<HeroProperties>().HasData(
                new { Id = 1, HeroId = 1, DifficultyRating = 3 },
                new { Id = 2, HeroId = 2, DifficultyRating = 1 },
                new { Id = 3, HeroId = 3, DifficultyRating = 1 },
                new { Id = 4, HeroId = 4, DifficultyRating = 2 },
                new { Id = 5, HeroId = 5, DifficultyRating = 2 },
                new { Id = 6, HeroId = 6, DifficultyRating = 3 },
                new { Id = 7, HeroId = 7, DifficultyRating = 1 },
                new { Id = 8, HeroId = 8, DifficultyRating = 2 },
                new { Id = 9, HeroId = 9, DifficultyRating = 2 },
                new { Id = 10, HeroId = 10, DifficultyRating = 2 },
                new { Id = 11, HeroId = 11, DifficultyRating = 3 },
                new { Id = 12, HeroId = 12, DifficultyRating = 2 },
                new { Id = 13, HeroId = 13, DifficultyRating = 1 },
                new { Id = 14, HeroId = 14, DifficultyRating = 1 },
                new { Id = 15, HeroId = 15, DifficultyRating = 2 },
                new { Id = 16, HeroId = 16, DifficultyRating = 2 },
                new { Id = 17, HeroId = 17, DifficultyRating = 1 },
                new { Id = 18, HeroId = 18, DifficultyRating = 2 },
                new { Id = 19, HeroId = 19, DifficultyRating = 2 },
                new { Id = 20, HeroId = 20, DifficultyRating = 1 },
                new { Id = 21, HeroId = 21, DifficultyRating = 1 },
                new { Id = 22, HeroId = 22, DifficultyRating = 3 },
                new { Id = 23, HeroId = 23, DifficultyRating = 3 },
                new { Id = 24, HeroId = 24, DifficultyRating = 1 },
                new { Id = 25, HeroId = 25, DifficultyRating = 2 },
                new { Id = 26, HeroId = 26, DifficultyRating = 2 },
                new { Id = 27, HeroId = 27, DifficultyRating = 2 },
                new { Id = 28, HeroId = 28, DifficultyRating = 2 }
                );


            #endregion

        }

    }
}
