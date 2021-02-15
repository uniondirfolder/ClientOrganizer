using System.Collections.Generic;
using System.Threading.Tasks;
using ClientOrganizer.Model;

namespace ClientOrganizer.UI.Data
{
    public interface IClientDataService
    {
        Task<Client> GetByIdAsync(int clientId);
    }
}