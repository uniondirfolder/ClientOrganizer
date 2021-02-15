

using ClientOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClientOrganizer.DataAccess
{

    public class ClientOrganizerDbContext : DbContext
    {
        public ClientOrganizerDbContext():base("Data Source =.; Initial Catalog = ClientOrganizer; Integrated Security = true")
        {

        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new ClientConfiguration());
                
        }
    }

    //public class ClientConfiguration : EntityTypeConfiguration<Client> 
    //{
    //    public ClientConfiguration()
    //    {
    //        Property(c => c.FirstName)
    //            .IsRequired()
    //            .HasMaxLength(50);
    //    }
    //}
}
