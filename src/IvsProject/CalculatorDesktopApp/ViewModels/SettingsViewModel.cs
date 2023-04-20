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
    public partial class SettingsViewModel : ViewModelBase
    {
        public ThemeModel ThemeModel { get; set; }
        private string _theme;
        private int _decimalPlaces;
        public string Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                ChangeTheme();
            }
        }

        public int DecimalPlaces
        {
            get => _decimalPlaces;
            set
            {
                _decimalPlaces = value;
                ChangeDecimalPlaces();
            }
        }
        public SettingsViewModel(IMessengerService messengerService) : base(messengerService)
        {
            ThemeModel = Settings.Theme;
            Theme = Settings.Theme.QuestionMarkSource == "qm_white.png" ? "Dark" : "Light";
            DecimalPlaces = Settings.DecimalPlaces;
        }

        private void ChangeTheme()
        {
            if (_theme == "Dark")
            {
                ThemeModel = ThemeModel.Dark;
                Settings.Theme = ThemeModel.Dark;
                MessengerService.Send(new ThemeMessage());
            }
            else
            {
                ThemeModel = ThemeModel.Light;
                Settings.Theme = ThemeModel.Light;
                MessengerService.Send(new ThemeMessage());
            }
        }

        private void ChangeDecimalPlaces()
        {
            Settings.DecimalPlaces = _decimalPlaces;
            MessengerService.Send(new DecimalPlacesMessage());
        }
    }
}
