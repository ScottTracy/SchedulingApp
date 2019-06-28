namespace SchedulingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterSchedules",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RoleId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MasterSchedules");
        }
    }
}
