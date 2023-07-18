using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace SimpleInventoryManagement.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy = false;

        [ObservableProperty]
        private string title = string.Empty;

        public bool IsNotBusy => !IsBusy;

        public BaseViewModel()
        {

        }
    }
}
