﻿using handball_IS.Objects.Actors.sub;
using handball_IS.Objects.Actors.super;
using handball_IS.Objects;
using Microsoft.EntityFrameworkCore;

namespace handball_IS.Utils
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentInstance> TournamentInstances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Recorder> Recorders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Referee> Referees { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:N Tournament - TournamentInstance
            modelBuilder.Entity<Tournament>()
                .HasMany(t => t.Editions)
                .WithOne(ti => ti.Tournament)
                .HasForeignKey(ti => ti.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N TournamentInstance - Category
            modelBuilder.Entity<TournamentInstance>()
                .HasMany(ti => ti.Categories)
                .WithOne(c => c.TournamentInstance)
                .HasForeignKey(c => c.TournamentInstanceId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Category - Group
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Groups)
                .WithOne(g => g.Category)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Group - Match
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Matches)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Team - Player
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Match - Event
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Events)
                .WithOne(e => e.Match)
                .HasForeignKey(e => e.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Club - Team
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Teams)
                .WithOne(t => t.Club)
                .HasForeignKey(t => t.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Category - Player
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Stats)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Category - Coach
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Voting)
                .WithOne(co => co.Category)
                .HasForeignKey(co => co.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:1 HomeTeam and AwayTeam - Match
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:1 MainReferee and AssistantReferee in Match
            modelBuilder.Entity<Match>()
                .HasOne(m => m.MainReferee)
                .WithMany(r => r.MainRefereeMatches)
                .HasForeignKey(m => m.MainRefereeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AssistantReferee)
                .WithMany(r => r.AssistantRefereeMatches)
                .HasForeignKey(m => m.AssistantRefereeId)
                .OnDelete(DeleteBehavior.Restrict);

            // TPT inheritance
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Coach>().ToTable("Coach");
            modelBuilder.Entity<Recorder>().ToTable("Recorder");
            modelBuilder.Entity<Referee>().ToTable("Referee");

            // Ignore navigation properties in database
            modelBuilder.Entity<Team>().Ignore(t => t.Group);
            modelBuilder.Entity<Group>().Ignore(g => g.Teams);
            modelBuilder.Entity<Match>().Ignore(m => m.Category);
            modelBuilder.Entity<Category>().Ignore(c => c.Matches);





        }

    }
}
