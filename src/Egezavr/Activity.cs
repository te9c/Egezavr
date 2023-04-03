using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr
{
    public class Activity
    {
        public Constants.Days Day { get; private set; }
        public int ExamOptionIndex { get; private set; }
        public TimeSpan TimeFrom { get; private set; }
        public TimeSpan TimeTo { get; private set; }

        public Activity(Constants.Days day, int examOptionIndex,
            TimeSpan timeFrom, TimeSpan timeTo)
        {
            Day = day;
            ExamOptionIndex = examOptionIndex;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
        }

        public bool IsValidActivity()
        {
            if (ExamOptionIndex == -1)
                return false;
            if (TimeTo < TimeFrom)
                return false;

            return true;
        }

        public VerticalStackLayout GetVerticalStack()
        {
            if (!IsValidActivity())
                throw new ArgumentException($"{this} is not valid");

            Grid grid = new()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                RowDefinitions =
                        {
                            new RowDefinition(),
                        },
                ColumnDefinitions =
                        {
                            new ColumnDefinition(),
                            new ColumnDefinition{ Width = new GridLength(40) },
                        },
            };
            grid.Add(new Button {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.Parse("white"),
                
            }, 0, 1);

            VerticalStackLayout activityStack = new() { 
                new Border
                {
                    Margin = new Thickness(0, 10, 0, 0),
                    HeightRequest = 75,
                    StrokeShape = new RoundRectangle {CornerRadius = 20 },
                    StrokeThickness = 3,
                    BackgroundColor = Color.FromArgb("#1282A2"),
                    Stroke = Color.FromArgb("#363F3E"),
                    Content = grid,
                    //Content = new Label
                    //{
                    //    Text = Constants.examOptions[ExamOptionIndex],
                    //    FontSize = 20,
                    //    TextColor = Color.Parse("Black"),
                    //    BackgroundColor = Color.FromArgb("#00000000"),
                    //    VerticalTextAlignment = TextAlignment.Center,
                    //    HorizontalTextAlignment = TextAlignment.Center,
                    //}
                }
            };
            

            return activityStack;
        }
    }
}
