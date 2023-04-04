using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;

namespace Egezavr;

public partial class PopupChooseActivity : Popup
{
	readonly Constants.Days day;
    int examOptionIndex = -1;
    VerticalStackLayout dayStack;

	public PopupChooseActivity(Constants.Days day, VerticalStackLayout dayStack)
	{
		this.day = day;
        this.dayStack = dayStack;
		InitializeComponent();

		ExamPicker.ItemsSource = Constants.examOptions;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Activity activity = new(day, examOptionIndex,
            ExamTimePickerFrom.Time, ExamTimePickerTo.Time, dayStack);
        if (!activity.IsValidActivity())
        {
            return; // implement incorrect input data message
        }
		Close(activity);
    }

    private void ExamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        examOptionIndex = ExamPicker.SelectedIndex;
    }
}