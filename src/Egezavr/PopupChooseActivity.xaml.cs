using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;

namespace Egezavr;

public partial class PopupChooseActivity : Popup
{
	readonly Constants.Days day;
    int examOptionIndex = -1;

	public PopupChooseActivity(Constants.Days day)
	{
		this.day = day;
		InitializeComponent();

		ExamPicker.ItemsSource = Constants.ExamOptions;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (examOptionIndex == -1)
            return;
        if (ExamTimePickerTo.Time < ExamTimePickerFrom.Time)
            return;

        Activity activity = new(day, examOptionIndex,
            ExamTimePickerFrom.Time, ExamTimePickerTo.Time);

		Close(activity);
    }

    private void ExamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        examOptionIndex = ExamPicker.SelectedIndex;
    }

    private void ExamTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Time")
        {
            if (sender == ExamTimePickerFrom)
                if (ExamTimePickerFrom.Time > ExamTimePickerTo.Time)
                    ExamTimePickerTo.Time = ExamTimePickerFrom.Time;

            if (sender == ExamTimePickerTo)
                if (ExamTimePickerTo.Time < ExamTimePickerFrom.Time)
                    ExamTimePickerFrom.Time = ExamTimePickerTo.Time;
        }
    }
}