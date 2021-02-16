

using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            Clients = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterClientSavedEvent>().Subscribe(AfterClientSaved);
        }

        private void AfterClientSaved(AfterClientSavedEventArgs obj)
        {
            var lookupItem = Clients.Single(l => l.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _clientLookupDataService.GetClientLookupAsync();
            Clients.Clear();
            foreach (var item in lookup)
            {
                Clients.Add(new NavigationItemViewModel(item.Id,item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Clients { get; }

        private NavigationItemViewModel _selectedClient;

        public NavigationItemViewModel SelectedClient
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
