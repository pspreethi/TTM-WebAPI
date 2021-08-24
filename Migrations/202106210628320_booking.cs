namespace BusBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                        End = c.String(),
                        Date = c.String(),
                        Seat = c.String(),
                        BusID = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Buses", t => t.BusID, cascadeDelete: true)
                .Index(t => t.BusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "BusID", "dbo.Buses");
            DropIndex("dbo.Bookings", new[] { "BusID" });
            DropTable("dbo.Bookings");
        }
    }
}
