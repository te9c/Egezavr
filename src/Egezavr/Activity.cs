using AndroidX.Lifecycle;
using Microsoft.Maui.Controls.Shapes;
using Org.Apache.Http.Conn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Egezavr
{
    public class Activity : Border
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

            Margin = new Thickness(0, 10, 0, 0);
            HeightRequest = 75;
            StrokeShape = new RoundRectangle { CornerRadius = 20 };
            StrokeThickness = 3;
            BackgroundColor = Color.FromArgb("#1282A2");
            Stroke = Color.FromArgb("#363F3E");

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
                    new ColumnDefinition{ Width = new GridLength(70) },
                },
            };

            Button exitButton = new()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Colors.Transparent,
            };
            grid.Add(exitButton, 1, 0);

            grid.Add(new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            });

            exitButton.Clicked += (sender, args) =>
            {
                var stack = Parent as StackBase;
                stack.Remove(this);
            };

            Content = grid;
        }

        public bool IsValidActivity()
        {
            if (ExamOptionIndex == -1)
                return false;
            if (TimeTo < TimeFrom)
                return false;

            return true;
        }
    }
}
