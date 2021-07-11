namespace AccountsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDealers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        CompanyFullName = c.String(),
                        CompanyPhoneNo = c.String(),
                        CompanyTelNo = c.String(),
                        RepresentativeName = c.String(),
                        CompanyAddress = c.String(),
                        RepresentativePhoneNo = c.String(),
                        Distribution = c.Boolean(nullable: false),
                        Reseller = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dealers");
        }
    }
}
