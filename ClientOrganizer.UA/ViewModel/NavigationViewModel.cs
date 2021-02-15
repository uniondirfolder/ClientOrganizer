

using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IClientLookupDataService _clientLookupDataService;

        public NavigationViewModel(IClientLookupDataService clientLookupDataService)
        {
            _clientLookupDataService = clientLookupDataService;
            Clients = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _clientLookupDataService.GetClientLookupAsync();
            Clients.Clear();
            foreach (var item in lookup)
            {
                Clients.Add(item);
            }
        }

        public ObservableCollection<LookupItem> Clients { get; }
    }
}
