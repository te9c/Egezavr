using Android.Util;
using CommunityToolkit.Maui.Views;
using Egezavr.Data;
using Microsoft.Maui.Controls.Internals;
using System.Collections.Immutable;

namespace Egezavr;

public partial class WeekPage : ContentPage
{
	public WeekPage()
	{
		InitializeComponent();

		List<ActivityItem> activities = App.ActivityRepository.GetActivities();
		foreach (var activityItem in activities)
		{
			var dayStack = MainVerticalStack[(int)activityItem.Day] as VerticalStackLayout;
			dayStack.Insert(dayStack.Count - 1, new Activity(
				activityItem.Day, activityItem.ExamOptionIndex, activityItem.TimeFrom, activityItem.TimeFrom, activityItem));
		}
    }

	private async void AddButtonClicked(object sender,EventArgs e)
	{
		Button btn = sender as Button ?? throw new ArgumentException($"{sender} is not Button");

		VerticalStackLayout dayStack = btn.Parent.Parent as VerticalStackLayout ?? throw new ArgumentException(btn.Parent.Parent.ToString());
		int index = MainVerticalStack.IndexOf(dayStack);
		if (index == -1) throw new ArgumentException($"{dayStack} is not in the {MainVerticalStack}");

		var popup = new PopupChooseActivity((Constants.Days)index);

		var result = await this.ShowPopupAsync(popup);

		if (result is Activity activity)
		{
			dayStack.Insert(dayStack.Count - 1, activity);
		}
    }

    private void DayStack_ChildAdded(object sender, ElementEventArgs e)
    {
		var stack = sender as VerticalStackLayout ?? throw new ArgumentException();

		bool itemMoved;
		do
		{
			itemMoved = false;
			for (int i = 0; i < stack.Count - 2; i++)
			{
				var activity = stack.Children[i] as Activity;
				var activityPlusOne = stack.Children[i + 1] as Activity;
				if (activity is null || activityPlusOne is null)
					continue;


				if (activity.TimeFrom > activityPlusOne.TimeFrom)
				{
					var lowerValue = activityPlusOne;
					
					stack.Remove(activity);
					stack.Remove(activityPlusOne);

					stack.Children.Insert(i, lowerValue);
                    stack.Children.Insert(i + 1, activity);

					itemMoved = true;
				}
			}
		} while (itemMoved);
    }
	
	//private async void SaveActivityList(object sender,  EventArgs e)
	//{
	//	var dayStack = sender as VerticalStackLayout ?? throw new ArgumentException(sender.ToString());
	//	var path = FileSystem.Current.AppDataDirectory;
	//	var fullPath = Path.Combine(path, "MyFile.txt");

		
	//	List<Activity> activityList = new();
	//	foreach (var i in dayStack)
	//	{
	//		if (i is Activity activity)
	//			activityList.Append(activity);
	//	}
	//}
}