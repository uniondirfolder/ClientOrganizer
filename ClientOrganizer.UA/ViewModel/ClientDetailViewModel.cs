

using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using ClientOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public class ClientDetailViewModel : ViewModelBase, IClientDetailViewModel
    {
        private IClientDataService _clientDataService;
        private IEventAggregator _eventAggregator;

        public ClientDetailViewModel(IClientDataService clientDataService,
            IEventAggregator eventAggregator)
        {
            _clientDataService = clientDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenClientDetailViewEvent>()
                .Subscribe(OnOpenClientDetailView);
        }

        private async void OnOpenClientDetailView(int clientId)
        {
            await LoadAsync(clientId);
        }

        public async Task LoadAsync(int clientId)
        {

            Client = await _clientDataService.GetByIdAsync(clientId);
        }

        private Client _client;

        public Client Client
        {
            get { return _client; }
            private set
            {
                _client = value;
                OnPropertyChanged();
            }
        }

    }
}
