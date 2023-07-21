using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.View;
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

		builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);

		builder.Services.AddSingleton<ItemsViewModel>();
		builder.Services.AddTransient<ItemsDetailsViewModel>();


		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ItemDetailsPage>();

        //dependency injection?
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<ItemService>(s));

        return builder.Build();
	}
}
