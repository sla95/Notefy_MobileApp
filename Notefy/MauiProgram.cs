using Notefy.ViewModels;
using Notefy.Views;

using Microsoft.Extensions.Logging;

namespace Notefy;

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

		// Services
		builder.Services.AddSingleton<Services.INoteService, Services.NoteService>();

		// Registration of Views
		builder.Services.AddSingleton<NoteListPage>();
        builder.Services.AddTransient<AddUpdateNoteDetail>();
		builder.Services.AddSingleton<ShoppingListPage>();


        // View Models
        builder.Services.AddSingleton<NoteListPageViewModel>();
        builder.Services.AddTransient<AddUpdateNoteDetailViewModel>();
		builder.Services.AddSingleton<ShoppingListViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

