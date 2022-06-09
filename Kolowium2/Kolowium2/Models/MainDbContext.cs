using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }



        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician_Track>(entity =>
            {
                entity.HasKey(e => new { e.IdTrack, e.IdMusician });
            });

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>()
                .HasData(
                new Musician
                {
                    IdMusician = 1,
                    FirstName = "Jakub",
                    LastName = "Nowak",
                    NickName = "Chudy"
                });
            modelBuilder.Entity<MusicLabel>()
                .HasData(
                new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "Kot"
                });
            modelBuilder.Entity<Album>()
                .HasData(
                new Album
                {
                    IdAlbum = 1,
                    AlbumName  = "Niebo",
                    PublishDate = DateTime.Parse("2022-02-02"),
                    IdMusicLabel = 1

                });

            modelBuilder.Entity<Track>()
                .HasData(
                new Track
                {
                    IdTrack = 1,
                    TrackName = "Niebo1",
                    Duration = 2,
                    IdMusicAlbum = 1
                });

            modelBuilder.Entity<Musician_Track>()
                .HasData(
                new Musician_Track
                {
                    IdTrack = 1,
                    IdMusician =1
                });

        }

    }
   


}