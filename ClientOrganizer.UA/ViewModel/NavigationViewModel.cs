

using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Event;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IClientLookupDataService _clientLookupDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IClientLookupDataService clientLookupDataService,
            IEventAggregator eventAggregator)
        {
            _clientLookupDataService = clientLookupDataService;
            _eventAggregator = eventAggregator;
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

        private LookupItem _selectedClient;

        public LookupItem SelectedClient
        {
            get { return _selectedClient; }
            set {
                _selectedClient = value;
                OnPropertyChanged();
                if (_selectedClient != null)
                {
                    _eventAggregator.GetEvent<OpenClientDetailViewEvent>()
                        .Publish(_selectedClient.Id);
                }
            }
        }

    }
}
