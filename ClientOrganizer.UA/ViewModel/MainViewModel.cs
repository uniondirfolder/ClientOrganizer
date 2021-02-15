using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClientOrganizer.Model;
using ClientOrganizer.UI.Data;

namespace ClientOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region refac
        //private readonly IClientDataService _clientDataService;
        //private Client _selectedClient;

        //public MainViewModel(IClientDataService clientDataService)
        //{
        //    _clientDataService = clientDataService;
        //    Clients = new ObservableCollection<Client>();
        //}

        //public async Task LoadAsync()
        //{
        //    var clients = await _clientDataService.GetAllAsync();
        //    Clients.Clear();
        //    foreach (var client in clients)
        //    {
        //        Clients.Add(client);
        //    }
        //}
        //public ObservableCollection<Client> Clients { get; set; }

        //public Client SelectedClient
        //{
        //    get => _selectedClient;
        //    set
        //    {
        //        _selectedClient = value;
        //        OnPropertyChanged();
        //    }
        //}
        #endregion

        public MainViewModel(INavigationViewModel navigationViewModel,
            IClientDetailViewModel clientDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            ClientDetailViewModel = clientDetailViewModel;
        }

        public async Task LoadAsync() 
        {
            await NavigationViewModel.LoadAsync();
        }
        public INavigationViewModel NavigationViewModel { get; }
        public IClientDetailViewModel ClientDetailViewModel { get; }
    }
}