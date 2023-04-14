﻿using Egezavr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr
{
    public static class Constants
    {
        public const string DatabaseFilename = "EgezavrActivites.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public static List<string> ExamOptions => new()
        {
            "ЕГЭ | Русский язык",
            "ЕГЭ | Математика базовая",
            "ЕГЭ | Математика профильная"
        };

        public static List<Color> ExamColors => new()
        {
            Color.FromArgb("#35C2E9"),
            Color.FromArgb("#F2C14E"),
            Color.FromArgb("#EBA2AA"),
        };

        /* Enchantment: add gradients instead of colors for activity background

        public static readonly List<LinearGradientBrush> examGradientColor = new()
        {
            new LinearGradientBrush
            {
                StartPoint = new Point(0,0),
                EndPoint = new Point(1,1),
                GradientStops =
                {
                    new GradientStop { Color = Colors.Yellow, Offset = 0f },
                    new GradientStop { Color = Colors.Red, Offset = 0.25f  },
                    new GradientStop { Color = Colors.Blue, Offset = 0.75f },
                    new GradientStop { Color = Colors.LimeGreen, Offset = 1f },
                }
            }
        }; */
    }
}
