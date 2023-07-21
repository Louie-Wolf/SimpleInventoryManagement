using SimpleInventoryManagement.ViewModel;

namespace SimpleInventoryManagement.View;

public partial class ItemDetailsPage : ContentPage
{
	public ItemDetailsPage(ItemsDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}