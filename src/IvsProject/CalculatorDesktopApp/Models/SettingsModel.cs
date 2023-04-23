using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDesktopApp.Models
{
    /// <summary>
    /// Data model for storing application setup
    /// </summary>
    public record SettingsModel : ModelBase
    {
        private static int DecimalPlaces { get; set; }
        private static ThemeModel Theme { get; set; }
    }
}
