using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDesktopApp.Models
{
    public record ThemeModel : ModelBase
    {
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Color ButtonNumbersColor { get; set; }
        public Color ButtonElseColor { get; set; }
        public Color SettingsSectionColor { get; set; }
        public string QuestionMarkSource { get; set; }
        public string SettingsSource { get; set; }

        public static ThemeModel Dark => new()
        {
            BackgroundColor = Color.FromRgb(27,33,35),
            TextColor = Color.FromRgb(255, 255, 255),
            ButtonNumbersColor = Color.FromRgb(59, 59, 59),
            ButtonElseColor = Color.FromRgb(50, 50, 50),
            SettingsSectionColor = Color.FromRgb(180, 180, 180),
            QuestionMarkSource = "qm_white.png",
            SettingsSource = "settings_white.png"
        };

        public static ThemeModel Light => new()
        {
            BackgroundColor = Color.FromRgb(235,235, 235),
            TextColor = Color.FromRgb(0,0,0),
            ButtonNumbersColor = Color.FromRgb(249, 249, 249),
            ButtonElseColor = Color.FromRgb(239, 239, 239),
            SettingsSectionColor = Color.FromRgb(40, 40, 40),
            QuestionMarkSource = "qm_black.png",
            SettingsSource = "settings_black.png"
        };
    }
}
