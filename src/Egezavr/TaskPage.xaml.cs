namespace Egezavr;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();
	}

    private async void AddButtonClicked(object sender, EventArgs e)
    {
		var result = await DisplayActionSheet("Выбрать предмет", "Отмена", null, Constants.TasksOptions.ToArray());
		if (Constants.TasksOptions.Contains(result))
		{
            int index = Constants.TasksOptions.IndexOf(result);
            foreach (var item in MainVerticalStack)
			{
				if (item is ActivityExpander activityExpander)
				{
					if (activityExpander.taskOptionsIndex == index)
						return;
				}
			}
			MainVerticalStack.Insert(MainVerticalStack.Count - 1, new ActivityExpander(index));
		}
    }
}