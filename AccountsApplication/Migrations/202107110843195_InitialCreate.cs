namespace AccountsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.AppUsers (Name, Username, Password, Type) VALUES (\'Admin\',\'admin\',\'admin123\',\'admin\')");
        }
        
        public override void Down()
        {
            DropTable("dbo.AppUsers");
        }
    }
}
