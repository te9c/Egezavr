using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Internals;

namespace Egezavr;

public partial class WeekPage : ContentPage
{
	public WeekPage()
	{
		InitializeComponent();

	}

	private async void AddButtonClicked(object sender,EventArgs e)
	{
		Button btn = sender as Button ?? throw new ArgumentException($"{sender} is not Button");

		VerticalStackLayout dayStack = btn.Parent.Parent as VerticalStackLayout ?? throw new ArgumentException(btn.Parent.Parent.ToString());
		int index = MainVerticalStack.IndexOf(dayStack);
		if (index == -1) throw new ArgumentException($"{dayStack} is not in the {MainVerticalStack}");

		var popup = new PopupChooseActivity((Constants.Days)index, dayStack);

		var result = await this.ShowPopupAsync(popup);

		if (result is Activity activity)
		{
			dayStack.Insert(dayStack.Count - 1, activity.GetVerticalStack());
		}
    }
}