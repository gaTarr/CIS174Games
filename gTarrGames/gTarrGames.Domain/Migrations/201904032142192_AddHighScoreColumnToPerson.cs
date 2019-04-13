namespace gTarrGames.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHighScoreColumnToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "HighScore_HighScoreId", c => c.Guid());
            CreateIndex("dbo.People", "HighScore_HighScoreId");
            AddForeignKey("dbo.People", "HighScore_HighScoreId", "dbo.HighScores", "HighScoreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "HighScore_HighScoreId", "dbo.HighScores");
            DropIndex("dbo.People", new[] { "HighScore_HighScoreId" });
            DropColumn("dbo.People", "HighScore_HighScoreId");
        }
    }
}
