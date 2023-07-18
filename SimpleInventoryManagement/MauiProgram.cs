using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.ViewModel;

namespace SimpleInventoryManagement;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		//dependency injection?
		builder.Services.AddSingleton<ItemService>(s => ActivatorUtilities.CreateInstance<ItemService>(s));

		builder.Services.AddSingleton<ItemsViewModel>();

		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
