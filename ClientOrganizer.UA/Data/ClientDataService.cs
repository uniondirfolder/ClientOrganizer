using System.Collections.Generic;
using ClientOrganizer.Model;

namespace ClientOrganizer.UI.Data
{
    public class ClientDataService : IClientDataService
    {
        //TODO: Load data from real database
        public IEnumerable<Client> GetAll()
        {
            yield return new Client{FirstName = "T", LastName = "F"};
            yield return new Client { FirstName = "T1", LastName = "F1" };
            yield return new Client { FirstName = "T2", LastName = "F2" };
            yield return new Client { FirstName = "T3", LastName = "F3" };
        }
    }
}