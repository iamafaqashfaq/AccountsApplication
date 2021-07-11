using AccountsApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApplication
{
    class AppContext : DbContext
    {
        public AppContext() : base("name=conn")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, AccountsApplication.Migrations.Configuration>());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
    }
}
