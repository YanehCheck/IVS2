using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDesktopApp.Models
{
    public record SettingsModel : ModelBase
    {
        private static int DecimalPlaces { get; set; }
        private static ThemeModel Theme { get; set; }
    }
}
