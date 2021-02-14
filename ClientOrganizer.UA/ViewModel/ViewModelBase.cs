using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientOrganizer.UI.Annotations;

namespace ClientOrganizer.UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}