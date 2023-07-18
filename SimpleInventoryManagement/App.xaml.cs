using SimpleInventoryManagement.Services;

namespace SimpleInventoryManagement;

public partial class App : Application
{
	public static ItemService ItemService {get; private set;}

	public App(ItemService itemService)
	{
		InitializeComponent();

		MainPage = new AppShell();

		ItemService = itemService;
	}
}
