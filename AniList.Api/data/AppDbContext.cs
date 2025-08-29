using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniList.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AniList.Api.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAnime>().HasKey(au => new { au.AnimeId, au.UserId });

            // Direct Many to Many relationship

            // modelBuilder.Entity<Anime>()
            // .HasMany(au => au.Users)
            // .WithMany(u => u.Animes)
            // .UsingEntity<AnimeUser>();

            // modelBuilder.Entity<Manga>()
            // .HasMany(mu => mu.Users)
            // .WithMany(mu => mu.Mangas)
            // .UsingEntity<MangaUser>();

            // Explicit Many to Many relationship

            modelBuilder.Entity<UserAnime>()
            .HasOne(ua => ua.User)
            .WithMany(ua => ua.AnimeList)
            .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnime>()
            .HasOne(ua => ua.Anime)
            .WithMany(ua => ua.Viewers)
            .HasForeignKey(ua => ua.AnimeId);

            // Configure composite key for UserManga
            modelBuilder.Entity<UserManga>().HasKey(um => new { um.MangaId, um.UserId });

            modelBuilder.Entity<UserManga>()
            .HasOne(um => um.Manga)
            .WithMany(um => um.Readers)
            .HasForeignKey(um => um.MangaId);

            modelBuilder.Entity<UserManga>()
            .HasOne(um => um.User)
            .WithMany(um => um.MangaList)
            .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<Anime>()
            .HasMany(ag => ag.Genres)
            .WithMany(ag => ag.Animes);

            modelBuilder.Entity<Manga>()
            .HasMany(g => g.Genres)
            .WithMany(m => m.Mangas);

        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnime> AnimeUsers { get; set; }
        public DbSet<UserManga> MangaUsers { get; set; }
    }
}