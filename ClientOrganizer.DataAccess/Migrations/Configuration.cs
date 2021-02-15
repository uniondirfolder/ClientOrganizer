namespace ClientOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientOrganizer.DataAccess.ClientOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ClientOrganizer.DataAccess.ClientOrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Clients.AddOrUpdate(
                c => c.FirstName,
                new Model.Client { FirstName="Thomas", LastName="Huber"},
                new Model.Client { FirstName = "Urs", LastName = "Meier" },
                new Model.Client { FirstName = "Erkan", LastName = "Egin" },
                new Model.Client { FirstName = "Sara", LastName = "Huber" }
                );
        }
    }
}
