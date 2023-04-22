using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr
{
    class ActivityExpander : Border
    {
        int AllCheckBoxes { get; set; } = 0;

        int AllCheckedCheckBoxes { get; set; } = 0;
        private ProgressBar ProgressBar { get; set; }
        public ActivityExpander(int examOptionIndex, List<string> checkboxOptions) {
            AllCheckedCheckBoxes = 0;

            // Border setup starts
            Margin = new Thickness(0, 10, 0, 0);
            StrokeShape = new RoundRectangle() { CornerRadius = 20, };
            StrokeThickness = 3;
            Stroke = Color.FromArgb("#363F3E");
            BackgroundColor = Constants.ExamColors[examOptionIndex];
            // Border setup ends

            Expander expander = new();
            Content = expander;
            expander.IsExpanded = false;

            // Header starts
            Grid grid = new()
            {
                HeightRequest = 75,
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition() { Width = new GridLength(75) },
                },
            };

            Image removeButtonImage = new()
            {
                Source = ImageSource.FromFile("arrowdown.svg"),
                HeightRequest = 75 * 0.7f,
                WidthRequest = 75 * 0.7f,
            };
            grid.Add(removeButtonImage, 1, 0);
            grid.SetRowSpan(removeButtonImage, 2);

            expander.PropertyChanged += (s, e) => { 
                if (e.PropertyName == "IsExpanded")
                {
                    if (expander.IsExpanded)
                    {
                        removeButtonImage.Source = ImageSource.FromFile("arrowup.svg");
                    }
                    else
                    {
                        removeButtonImage.Source = ImageSource.FromFile("arrowdown.svg");
                    }
                }
            };

            grid.Add(new Label
            {
                Text = Constants.ExamOptions[examOptionIndex],
                VerticalTextAlignment = TextAlignment.End,
                FontSize = 18,
                Margin = new Thickness(15, 0, 0, 0),
                TextColor = Colors.Black,
            }, 0, 0);
            Grid progressBarGrid = new()
            {
                Margin = new Thickness(15, 0, 0, 0),
                ColumnSpacing = 10,
                RowDefinitions =
                {
                    new RowDefinition(),
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(6, GridUnitType.Star) },
                }
            };
            ProgressBar = new()
            {
                Progress = 0,
                ProgressColor = Colors.SeaGreen,
                HorizontalOptions = LayoutOptions.Fill,
            };
            Label progressPercentageLabel = new()
            {
                Text = $"{ProgressBar.Progress * 100}%",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 14,
            };
            ProgressBar.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Progress")
                {
                    progressPercentageLabel.Text = $"{ProgressBar.Progress * 100}%";
                };
            };
            progressBarGrid.Add(ProgressBar,1, 0);
            progressBarGrid.Add(progressPercentageLabel, 0, 0);
            grid.Add(progressBarGrid, 0, 1);



            expander.Header = grid;
            // Header ends

            VerticalStackLayout contentStack = new() { 
                Margin = new Thickness(10),
            };
            expander.Content = contentStack;

            // Content starts

            foreach (string str in checkboxOptions)
            {
                AllCheckBoxes++;
                CheckBox checkBox = new CheckBox();
                checkBox.CheckedChanged += (s, e) =>
                {
                    if (checkBox.IsChecked)
                    {
                        AllCheckedCheckBoxes++;
                    }
                    else
                    {
                        AllCheckedCheckBoxes--;
                    }

                    ProgressBar.Progress = AllCheckedCheckBoxes / AllCheckBoxes;
                };
                contentStack.Add(new HorizontalStackLayout
                {
                    Children =
                    {
                        checkBox,
                        new Label() { Text = str, VerticalTextAlignment = TextAlignment.Center },
                    }
                });
            }
        }
    }
}
