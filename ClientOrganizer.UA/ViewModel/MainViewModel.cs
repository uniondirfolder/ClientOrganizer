using System.Collections.ObjectModel;
using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;

namespace ClientOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IClientDataService _clientDataService;
        private Client _selectedClient;

        public MainViewModel(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService;
            Clients = new ObservableCollection<Client>();
        }

        public void Load()
        {
            var clients = _clientDataService.GetAll();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }
        public ObservableCollection<Client> Clients { get; set; }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

       
    }
}