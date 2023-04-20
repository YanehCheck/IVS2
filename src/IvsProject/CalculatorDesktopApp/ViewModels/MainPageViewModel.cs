using System;
using System.Globalization;
using CalculatorDesktopApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using SharpHook.Reactive;
using System.Reflection.Metadata;
using SharpHook;
using SharpHook.Native;
using System.Reactive.Linq;
using CalculatorDesktopApp.Messages;
using CalculatorDesktopApp.Services.Interfaces;
using CalculatorModel;
using CommunityToolkit.Mvvm.Messaging;

namespace CalculatorDesktopApp.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase, IRecipient<DecimalPlacesMessage>, IRecipient<ThemeMessage>
    {
        public ThemeModel Theme { get; set; }
        public double ExpressionHeight { get; set; } 
        public double ExpressionFontSize { get; set; } = 40;
        public string Expression { get; set; } = "";
        public string Result { get; set; } = "";
        private Calculator Calculator { get; set; }
        private readonly Color _ok = new (161, 96, 251);
        private readonly Color _ko = new (255, 0, 0);
        private string LastKey { get; set; } = "$";
        public Color ResultColor { get; set; } = new ();

        public MainPageViewModel(IMessengerService messengerService) : base(messengerService)
        {
            Settings.DecimalPlaces = 5;
            Settings.Theme = ThemeModel.Dark;
            Calculator = new Calculator(Settings.DecimalPlaces);
            Theme = Settings.Theme;

            var hook = new SimpleReactiveGlobalHook();
            hook.KeyPressed.Subscribe(e => OnKeyDown(e.Data.KeyCode));
            hook.RunAsync();
        }

        private string KeyCodeToString(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.VcNumPad0:
                {
                    return "0";
                }
                case KeyCode.VcNumPad1:
                {
                    return "1";
                }
                case KeyCode.VcNumPad2:
                {
                    return "2";
                }
                case KeyCode.VcNumPad3:
                {
                    return "3";
                }
                case KeyCode.VcNumPad4:
                {
                    return "4";
                }
                case KeyCode.VcNumPad5:
                {
                    return "5";
                }
                case KeyCode.VcNumPad6:
                {
                    return "6";
                }
                case KeyCode.VcNumPad7:
                {
                    return "7";
                }
                case KeyCode.VcNumPad8:
                {
                    return "8";
                }
                case KeyCode.VcNumPad9:
                {
                    return "9";
                }
                case KeyCode.VcNumPadSeparator:
                case KeyCode.VcPeriod:
                {
                    return "•";
                }
                case KeyCode.VcLeftControl:
                {
                    return "ctrl";
                }
                case KeyCode.VcC:
                {
                    return "c";
                }
                case KeyCode.VcNumPadAdd:
                {
                    return "+";
                }
                case KeyCode.VcNumPadSubtract:
                {
                    return "-";
                }
                case KeyCode.VcNumPadMultiply:
                {
                    return "*";
                }
                case KeyCode.VcNumPadDivide:
                {
                    return "/";
                }
                case KeyCode.VcOpenBracket:
                {
                    return "(";
                }
                case KeyCode.VcCloseBracket:
                {
                    return ")";
                }
                case KeyCode.VcBackspace:
                {
                    return "CE";
                }
                case KeyCode.VcEnter:
                case KeyCode.VcNumPadEnter:
                {
                    return "=";
                }
                case KeyCode.VcF1:
                {
                    return "MC";
                }
                case KeyCode.VcF2:
                {
                    return "MR";
                }
                case KeyCode.VcF3:
                {
                    return "M+";
                }
                case KeyCode.VcF4:
                {
                    return "M-";
                }
                case KeyCode.VcF5:
                {
                    return "MS";
                }
                default:
                {
                    return "$";
                }
            }
        }
        private void OnKeyDown(KeyCode keyCode)
        {
            System.Diagnostics.Debug.WriteLine(ExpressionHeight);
            var actualKey = KeyCodeToString(keyCode);
            if (LastKey == "ctrl" && actualKey == "c")
            {
                if (!string.IsNullOrWhiteSpace(Result))
                {
                    CopyResultToClipboard();
                }
            }
            else if (actualKey is "$" or "ctrl" or "c")
            {

            }
            else
            {
                ButtonPressed(actualKey);
            }
            LastKey = actualKey;
        }

        public async void CopyResultToClipboard()
        {
            if (Application.Current != null)
                await Application.Current.Dispatcher.DispatchAsync(() => { Clipboard.SetTextAsync(Result); });
        }

        [RelayCommand]
        private void ButtonPressed(string parameter)
        {
            switch (parameter)
            {
                case "MC":
                {
                    Calculator.Memory.MC();
                    break;
                }
                case "MR":
                {
                    Expression += Convert.ToString(Calculator.Memory.MR(), CultureInfo.InvariantCulture);
                    break;
                }
                case "M+":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MPlus(Convert.ToDecimal(Result));
                    }
                    break;
                }
                case "M-":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MMinus(Convert.ToDecimal(Result));
                    }
                    break;
                }
                case "MS":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MS(Convert.ToDecimal(Result));
                    }
                    break;
                }
                case "CE":
                {
                    Result = "";
                    if (Expression.Length == 0) return;
                    Expression = Expression.Substring(0, Expression.Length - 1);
                    break;
                }
                case "•":
                {
                    Result = "";
                    Expression += ".";
                    break;
                }
                case "=":
                {
                    Result = "";
                    if (string.IsNullOrWhiteSpace(Expression))
                    {
                        return;
                    }
                    var result = Calculator.Calculate(Expression
                        .Replace(",",".")
                        .Replace("÷", "/")
                        .Replace("x", "*"));
                    if (result.ErrorType == CalculationErrorType.None)
                    {
                        ResultColor = _ok;
                        Result = Convert.ToString(result.Value);
                    }
                    else
                    {
                        ResultColor = _ko;
                        Result = "Error";
                    }
                    break;
                }
                default:
                {
                    Result = "";
                    Expression += parameter;
                    break;
                }
            }
        }

        [RelayCommand]
        private async Task GoToSettingsAsync()
        {
            System.Diagnostics.Debug.WriteLine("Go to Settings");
            await Shell.Current.GoToAsync("settings");
        }

        [RelayCommand]
        private async Task GoToHelpAsync()
        {
            System.Diagnostics.Debug.WriteLine("Go to Help");
            await Shell.Current.GoToAsync("help");
        }

        public void Receive(DecimalPlacesMessage message)
        {
            System.Diagnostics.Debug.WriteLine("Changing decimal places");
            Calculator = new Calculator(Settings.DecimalPlaces);
        }

        public void Receive(ThemeMessage message)
        {
            System.Diagnostics.Debug.WriteLine("Changing theme");
            Theme = Settings.Theme;
        }
    }
}
