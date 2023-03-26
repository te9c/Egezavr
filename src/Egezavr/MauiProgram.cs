using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

namespace Egezavr;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
	
	public enum Days
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	public static List<string> examOptions = new() { 
		"ЕГЭ | Русский язык",
		"ЕГЭ | Математика базовая",
		"ЕГЭ | Математика профильная"
	};
}
