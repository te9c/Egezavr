using Android.App;
using AndroidX.Lifecycle;
using Egezavr.Data;
using Microsoft.Maui.Controls.Shapes;
using Org.Apache.Http.Conn;
using Plugin.LocalNotification;
using SQLite;
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
        public ActivityItem CurrentActivityItem { get; private set; }

        public Activity(Constants.Days day, int examOptionIndex,
            TimeSpan timeFrom, TimeSpan timeTo) : this(day,examOptionIndex, timeFrom, timeTo, new ActivityItem()) { }

        public Activity(Constants.Days day, int examOptionIndex,
            TimeSpan timeFrom, TimeSpan timeTo, ActivityItem activityItem)
        {
            if (activityItem.ID == 0)
            {
                activityItem = new() { Day = day, ExamOptionIndex = examOptionIndex, TimeFrom = timeFrom, TimeTo = timeTo };
                App.ActivityRepository.SaveActivity(activityItem);
                CurrentActivityItem = activityItem;

                var request = new NotificationRequest
                {
                    NotificationId = CurrentActivityItem.ID,
                    Title = $"Начинается занятие!",
                    Description = $"{Constants.ExamOptions[examOptionIndex]}",
                    Subtitle = "Занятие",
                    BadgeNumber = 42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = CalculateDateTime(day, timeFrom),
                        NotifyRepeatInterval = TimeSpan.FromDays(7),
                    },
                    Android =
                    {
                        IconSmallName =
                        {
                            ResourceName = "notificationicon"
                        }
                    }
                };
                LocalNotificationCenter.Current.Show(request);
            }
            else
            {
                CurrentActivityItem = activityItem;
            }

            Day = day;
            ExamOptionIndex = examOptionIndex;
            TimeFrom = timeFrom;
            TimeTo = timeTo;

            Margin = new Thickness(0, 10, 0, 0);
            HeightRequest = 75; // could be 93.75 if box is to small
            StrokeShape = new RoundRectangle { CornerRadius = 20 };
            StrokeThickness = 3;
            BackgroundColor = Constants.ExamColors[examOptionIndex];
            //Background = Constants.examGradientColor[0];
            Stroke = Color.FromArgb("#363F3E");

            Grid grid = new()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                RowSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1.5,GridUnitType.Star) },
                    new RowDefinition{ },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition{ Width = new GridLength(75) },
                },
            };

            Button exitButton = new()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Colors.Transparent,
                // Source = ImageSource.FromFile("x_circle.svg"),
            };
            Image exitButtonImage = new()
            {
                Source = ImageSource.FromFile("x_circle.svg"),
                WidthRequest = HeightRequest * 0.7,
                HeightRequest = HeightRequest * 0.7,
            };
            grid.Add(exitButtonImage, 1, 0);
            grid.Add(exitButton, 1, 0);
            grid.SetRowSpan(exitButton, 2);
            grid.SetRowSpan(exitButtonImage, 2);

            grid.Add(new Label
            {
                Text = Constants.ExamOptions[examOptionIndex],
                VerticalTextAlignment = TextAlignment.End,
                FontSize = 18,
                Margin = new Thickness(15, 0, 0, 0),
                TextColor = Colors.Black,
            }, 0, 0);
            grid.Add(new Label
            {
                Text = $"{TimeFrom:hh\\:mm}-{TimeTo:hh\\:mm}",
                VerticalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(15, 0, 0, 0),
                TextColor = Colors.Black
            }, 0, 1);

            exitButton.Clicked += (sender, args) =>
            {
                var stack = Parent as StackBase;
                stack.Remove(this);
                App.ActivityRepository.DeleteActivity(CurrentActivityItem);
                LocalNotificationCenter.Current.Clear(CurrentActivityItem.ID);
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

        private static DateTime CalculateDateTime(Constants.Days day, TimeSpan timeFrom)
        {
            DateTime dateTime = DateTime.Today;
            
            Constants.Days dayOfWeek = Constants.Days.Monday;
            if ((int)dateTime.DayOfWeek == 0)
                dayOfWeek = Constants.Days.Sunday;
            else
                dayOfWeek += (int)dateTime.DayOfWeek - 1;

            if ((int)day >= (int)dayOfWeek)
                dateTime = dateTime.AddDays((int)day - (int)dayOfWeek);
            else
                dateTime = dateTime.AddDays(6 - (int)dayOfWeek + (int)day + 1);
            dateTime = dateTime.AddMinutes(timeFrom.TotalMinutes);

            return dateTime;
        }
    }
}
