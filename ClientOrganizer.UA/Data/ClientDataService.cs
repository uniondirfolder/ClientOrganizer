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
        public async Task<List<Client>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Clients.AsNoTracking().ToListAsync();
            }
            //yield return new Client{FirstName = "T", LastName = "F"};
            //yield return new Client { FirstName = "T1", LastName = "F1" };
            //yield return new Client { FirstName = "T2", LastName = "F2" };
            //yield return new Client { FirstName = "T3", LastName = "F3" };
        }
    }
}