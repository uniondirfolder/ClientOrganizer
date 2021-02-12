using System.Collections.Generic;
using ClientOrganizer.Model;

namespace ClientOrganizer.UI.Data
{
    public interface IClientDataService
    {
        IEnumerable<Client> GetAll();
    }
}