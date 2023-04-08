using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egezavr
{
    public static class Constants
    {
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

        public static readonly List<string> examOptions = new()
        {
            "ЕГЭ | Русский язык",
            "ЕГЭ | Математика базовая",
            "ЕГЭ | Математика профильная"
        };

        public static readonly List<Color> examColors = new()
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
