

using Autofac;
using ClientOrganizer.UI.ViewModel;

namespace ClientOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ClientOrganizer.DataAccess.ClientOrganizerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<ViewModel.MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ClientDetailViewModel>().As<IClientDetailViewModel>();

            builder.RegisterType<ClientOrganizer.UI.Data.LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<Data.ClientDataService>().As<Data.IClientDataService>();

            return builder.Build();
        }
    }
}
