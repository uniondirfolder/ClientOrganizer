using System.Collections.Generic;
using ClientOrganizer.Model;
using System.Linq;
using System;
using ClientOrganizer.DataAccess;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClientOrganizer.UI.Data
{
    public class ClientDataService : IClientDataService
    {
        private Func<ClientOrganizerDbContext> _contextCreator;

        public ClientDataService(Func<ClientOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        //TODO: Load data from real database
        public async Task<Client> GetByIdAsync(int clientId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Clients.AsNoTracking().SingleAsync(c=>c.Id==clientId);
            }
        }

        public async Task SaveAsync(Client client)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Clients.Attach(client);
                ctx.Entry(client).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}