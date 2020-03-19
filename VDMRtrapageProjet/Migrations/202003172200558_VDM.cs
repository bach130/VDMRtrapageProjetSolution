namespace VDMRtrapageProjet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VDM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "tarif", c => c.Double(nullable: false));
            DropColumn("dbo.Salles", "tarif");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salles", "tarif", c => c.Double(nullable: false));
            DropColumn("dbo.Reservations", "tarif");
        }
    }
}
