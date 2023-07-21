using SimpleInventoryManagement.View;

namespace SimpleInventoryManagement;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ItemDetailsPage), typeof(ItemDetailsPage));
	}
}
