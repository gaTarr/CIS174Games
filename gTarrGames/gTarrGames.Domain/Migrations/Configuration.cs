using gTarrGames.Domain.Entities;

namespace gTarrGames.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<gTarrGames.Domain.GamesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(gTarrGames.Domain.GamesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Persons.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                FirstName = "Greg",
                LastName = "Tarr",
                DateCreated = DateTime.Now,
                Email = "gatarr@dmacc.edu"
            });

            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("9da277e5-a9dc-4399-8ade-d9d3a7aa0cee"),
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                Score = 49,
                DateAttained = new DateTime(2019, 02, 10)
            });
            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("fe303a12-d489-4ead-b2cd-23d0cf262c2e"),
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                Score = 99,
                DateAttained = new DateTime(2019, 02, 10)
            });
            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("bcb549d3-1a8f-40f9-a65f-cf8fa7676b27"),
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                Score = 56,
                DateAttained = new DateTime(2019, 02, 10)
            });
            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("a4cc153e-3633-4923-8eaa-a57ad501d829"),
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                Score = 12,
                DateAttained = new DateTime(2019, 02, 10)
            });
            context.HighScores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("271d3151-3d11-4860-b276-568c6ac7a1ea"),
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                Score = 96,
                DateAttained = new DateTime(2019, 02, 10)
            });
        }
    }
}
