using ClientOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.Data
{
    public interface IClientLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetClientLookupAsync();
    }
}