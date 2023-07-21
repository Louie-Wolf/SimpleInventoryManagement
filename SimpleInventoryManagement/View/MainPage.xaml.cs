using SimpleInventoryManagement.ViewModel;

namespace SimpleInventoryManagement;

public partial class MainPage : ContentPage
{
	public MainPage(ItemsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

