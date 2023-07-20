using SimpleInventoryManagement.ViewModel;

namespace SimpleInventoryManagement;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(ItemsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

