using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;

namespace Egezavr;

public partial class PopupChooseActivity : Popup
{
	MauiProgram.Days day;
    int examOptionIndex = -1;

	public PopupChooseActivity(MauiProgram.Days day)
	{
		this.day = day;
		InitializeComponent();

		ExamPicker.ItemsSource = MauiProgram.examOptions;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (examOptionIndex == -1)
        {
            return; // implement incorrect input data message
        }


        VerticalStackLayout activityStack = new();
        activityStack.Add(new Border
        {
            Margin = new Thickness(0, 10, 0, 0),
            HeightRequest = 75,
            StrokeShape = new RoundRectangle() { CornerRadius = 20 },
            StrokeThickness = 3,
            BackgroundColor = Color.FromArgb("#E9E9E9"),
            Stroke = Color.FromArgb("#363F3E"),
            StrokeDashArray = new() { 1, 1 },
            StrokeDashOffset = 1,
        }
        .Content = new Label()
        {
            Text = MauiProgram.examOptions[examOptionIndex],
            FontSize=20,
            TextColor = Color.Parse("Black"),
            BackgroundColor = Color.FromArgb("#00000000"),
        }
        );

        

		Close(activityStack);
    }

    private void ExamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        examOptionIndex = ExamPicker.SelectedIndex;
    }
}