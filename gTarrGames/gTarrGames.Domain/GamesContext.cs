using gTarrGames.Domain.Entities;
using System.Data.Entity;

namespace gTarrGames.Domain
{
    public class GamesContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<HighScore> HighScores { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
