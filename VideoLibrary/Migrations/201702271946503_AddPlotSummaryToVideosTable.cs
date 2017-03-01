namespace VideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlotSummaryToVideosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "PlotSummary", c => c.String(nullable: true, maxLength: 510));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vidoes", "PlotSummary");
        }
    }
}
