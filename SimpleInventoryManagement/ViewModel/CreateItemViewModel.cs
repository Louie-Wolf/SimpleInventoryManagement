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

                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo == null)
                {
#if DEBUG
                    await Shell.Current.DisplayAlert("Error!", "Photo is null!", "OK");
#endif
                    return;
                }

                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);


                IsBusy = true; //Todo: replacce placeholder with ui content
                await itemService.AddNewItem("PLACEHOLDER", localFilePath);

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
