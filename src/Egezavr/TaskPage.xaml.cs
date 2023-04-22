namespace Egezavr;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();
		MainVerticalStack.Add(new ActivityExpander(2, new List<string>(){ "some string" }));
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
    }
}