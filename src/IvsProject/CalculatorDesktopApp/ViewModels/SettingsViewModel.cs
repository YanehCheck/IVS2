using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorDesktopApp.Messages;
using CalculatorDesktopApp.Models;
using CalculatorDesktopApp.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorDesktopApp.ViewModels
{
    /// <summary>
    /// ViewModel for Calculator settings
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Application theme
        /// </summary>
        public ThemeModel ThemeModel { get; set; }

        /// <summary>
        /// A string representation of the application's theme
        /// </summary>
        private string _theme;

        /// <summary>
        /// Int representation of decimal numbers
        /// </summary>
        private int _decimalPlaces;

        /// <summary>
        /// A string representation of the application's theme
        /// </summary>
        public string Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                ChangeTheme();
            }
        }

        /// <summary>
        /// Int representation of decimal numbers
        /// </summary>
        public int DecimalPlaces
        {
            get => _decimalPlaces;
            set
            {
                _decimalPlaces = value;
                ChangeDecimalPlaces();
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SettingsViewModel"/> type.
        /// </summary>
        /// <param name="messengerService"> Sending messages between ViewModels. </param>
        public SettingsViewModel(IMessengerService messengerService) : base(messengerService)
        {
            ThemeModel = Settings.Theme;
            Theme = Settings.Theme.QuestionMarkSource == "qm_white.png" ? "Dark" : "Light";
            DecimalPlaces = Settings.DecimalPlaces;
        }

        /// <summary>
        /// Setting a new app theme and sending a message about it to other ViewModels
        /// </summary> 
        private void ChangeTheme()
        {
            if (_theme == "Dark")
            {
                ThemeModel = ThemeModel.Dark;
                Settings.Theme = ThemeModel.Dark;
                Preferences.Set("theme", "dark");
                MessengerService.Send(new ThemeMessage());
            }
            else
            {
                ThemeModel = ThemeModel.Light;
                Settings.Theme = ThemeModel.Light;
                Preferences.Set("theme", "light");
                MessengerService.Send(new ThemeMessage());
            }
        }

        /// <summary>
        /// Setting a new decimal places and sending a message about it to other ViewModels
        /// </summary> 
        private void ChangeDecimalPlaces()
        {
            Settings.DecimalPlaces = _decimalPlaces;
            Preferences.Set("decimalPlaces", Convert.ToString(_decimalPlaces));
            MessengerService.Send(new DecimalPlacesMessage());
        }
    }
}