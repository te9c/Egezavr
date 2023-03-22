namespace Egezavr;

public partial class WeekPage : ContentPage
{
	public WeekPage()
	{
		InitializeComponent();

	}

	private async void AddButtonClicked(object sender,EventArgs e)
	{
		Button button = sender as Button ?? throw new ArgumentException($"{sender} is not Button type");
		
		Border buttonBorder = button.Parent as Border ?? throw new ArgumentException($"Parent of {button} is not Border");

        VerticalStackLayout dayStack = buttonBorder.Parent as VerticalStackLayout ?? throw new ArgumentException($"Parent of {buttonBorder} is not VerticalStackLayout");

        var action = await DisplayActionSheet("Выбрать язык", "Отмена", "Удалить", "C#", "JavaScript", "Java");
    }
}