﻿using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Model;
using SimpleInventoryManagement.View;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimpleInventoryManagement.ViewModel
{
    public partial class ItemsViewModel : BaseViewModel
    {
        private ItemService itemService;
        public ObservableCollection<Item> Items { get; } = new ();

        public ItemsViewModel(ItemService itemService)
        {
            Title = "Items Finder";
            this.itemService = itemService;

        }

        [RelayCommand]
        private async Task GoToDetailsAsync(Item item)
        {
            if (item is null)
                return;
            //interface instead of shell reference?
            await Shell.Current.GoToAsync($"{nameof(ItemDetailsPage)}",true, 
                new Dictionary<string, object> 
                { 
                    { "Item", item } 
                });
        }

        [RelayCommand]
        private async Task GetItemsAsync()
        {
            if(IsBusy)
                return;

            try
            {
                IsBusy = true;
                var items = await itemService.GetAllItems();

                if(Items.Count > 0)
                    Items.Clear();

                foreach(var item in items)
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

#if DEBUG //should not actually display the error in the real app!
                await Shell.Current.DisplayAlert("Error!", $"Unable to get items: {ex.Message}", "OK");
#endif
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
