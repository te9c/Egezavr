using Egezavr.Data;

namespace Egezavr;

public partial class App : Application
{
	public static ActivityRepository ActivityRepository { get; private set; }
	public App(ActivityRepository activityRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		ActivityRepository = activityRepository;
	}
}
