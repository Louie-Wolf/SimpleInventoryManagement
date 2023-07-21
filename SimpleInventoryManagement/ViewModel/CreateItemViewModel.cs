using CommunityToolkit.Mvvm.Input;
using SimpleInventoryManagement.Services;
using System.Diagnostics;

namespace SimpleInventoryManagement.ViewModel
{
    public partial class CreateItemViewModel : BaseViewModel
    {
        private ItemService itemService;
        private IMediaPicker mediaPicker;

        public CreateItemViewModel(ItemService itemService)
        {
            Title = "Erstelle Eintrag";
            this.itemService = itemService;
        }

        [RelayCommand]
        private async Task CreateItemAsync()
        {
            if(IsBusy)
                return;

            try
            {
                if (!mediaPicker.IsCaptureSupported)
                {
#if DEBUG
                    await Shell.Current.DisplayAlert("Error!", "Capture is not supported!", "OK");
#endif
                    return;
                }
                IsBusy = true; //Todo: replacce placeholder with ui content
                await itemService.AddNewItem("PLACEHOLDER", "PLACEHOLDER");

            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
#if DEBUG
                await Shell.Current.DisplayAlert("Error!", $"Unable to get items: {e.Message}", "OK");
#endif
            }
            finally 
            { 
                IsBusy = false; 
            }
        }
    }
}
