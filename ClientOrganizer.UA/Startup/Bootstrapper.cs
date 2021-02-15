

using Autofac;

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
            builder.RegisterType<Data.ClientDataService>().As<Data.IClientDataService>();

            return builder.Build();
        }
    }
}
