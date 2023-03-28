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

        public static readonly List<string> examOptions = new() {
        "ЕГЭ | Русский язык",
        "ЕГЭ | Математика базовая",
        "ЕГЭ | Математика профильная"
    };
    }
}
