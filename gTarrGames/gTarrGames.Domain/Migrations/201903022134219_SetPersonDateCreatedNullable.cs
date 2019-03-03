namespace gTarrGames.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetPersonDateCreatedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
