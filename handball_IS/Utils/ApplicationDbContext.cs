using handball_IS.Objects.Actors.sub;
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
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Vote> Votes { get; set; }
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

        }

    }
}
