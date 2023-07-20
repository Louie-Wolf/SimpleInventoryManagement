using SimpleInventoryManagement.ViewModel;

namespace SimpleInventoryManagement;

public partial class CreateItemPage : ContentPage
{
	public CreateItemPage(CreateItemViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}