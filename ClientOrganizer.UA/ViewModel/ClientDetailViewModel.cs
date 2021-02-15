

using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;
using System.Threading.Tasks;

namespace ClientOrganizer.UI.ViewModel
{
    public class ClientDetailViewModel : ViewModelBase, IClientDetailViewModel
    {
        private readonly IClientDataService _clientDataService;

        public ClientDetailViewModel(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService;
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
