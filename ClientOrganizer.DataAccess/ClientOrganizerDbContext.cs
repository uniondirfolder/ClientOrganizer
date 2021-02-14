

using ClientOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClientOrganizer.DataAccess
{
    public class ClientOrganizerDbContext : DbContext
    {
        public ClientOrganizerDbContext():base("ClientOrganizerDb")
        {

        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
