namespace gTarrGames.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorLogEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        ErrorId = c.Guid(nullable: false),
                        ErrorDateTime = c.DateTime(nullable: false),
                        ErrorMessage = c.String(),
                        StackTrace = c.String(),
                        InnerExceptions = c.String(),
                    })
                .PrimaryKey(t => t.ErrorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
