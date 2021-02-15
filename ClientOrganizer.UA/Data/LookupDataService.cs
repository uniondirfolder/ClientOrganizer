

using ClientOrganizer.DataAccess;
using ClientOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.Data
{
    public class LookupDataService : IClientLookupDataService
    {
        private readonly Func<ClientOrganizerDbContext> contextCreator;

        public LookupDataService(Func<ClientOrganizerDbContext> contextCreator)
        {
            this.contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetClientLookupAsync()
        {
            using (var ctx = contextCreator())
            {
                return await ctx.Clients.AsNoTracking()
                    .Select(c =>
                    new LookupItem { Id = c.Id, DisplayMember = c.FirstName + " " + c.LastName })
                    .ToListAsync();
            }
        }
    }
}
