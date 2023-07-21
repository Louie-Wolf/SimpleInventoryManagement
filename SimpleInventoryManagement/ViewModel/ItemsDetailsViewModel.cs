using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleInventoryManagement.Model;

namespace SimpleInventoryManagement.ViewModel
{
    [QueryProperty("Item","Item")]
    public partial class ItemsDetailsViewModel : BaseViewModel
    {
        public ItemsDetailsViewModel()
        {

        }

        [ObservableProperty]
        Item item;
    }
}
