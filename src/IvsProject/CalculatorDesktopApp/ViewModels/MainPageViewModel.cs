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

        private string KeyCodeToString(KeyCode keyCode) {
            return keyCode switch {
                KeyCode.VcNumPad0 => "0",
                KeyCode.VcNumPad1 => "1",
                KeyCode.VcNumPad2 => "2",
                KeyCode.VcNumPad3 => "3",
                KeyCode.VcNumPad4 => "4",
                KeyCode.VcNumPad5 => "5",
                KeyCode.VcNumPad6 => "6",
                KeyCode.VcNumPad7 => "7",
                KeyCode.VcNumPad8 => "8",
                KeyCode.VcNumPad9 => "9",
                KeyCode.VcNumPadSeparator => "•",
                KeyCode.VcPeriod => "•",
                KeyCode.VcLeftControl => "ctrl",
                KeyCode.VcC => "c",
                KeyCode.VcNumPadAdd => "+",
                KeyCode.VcNumPadSubtract => "-",
                KeyCode.VcNumPadMultiply => "*",
                KeyCode.VcNumPadDivide => "/",
                KeyCode.VcOpenBracket => "(",
                KeyCode.VcCloseBracket => ")",
                KeyCode.VcBackspace => "CE",
                KeyCode.VcEnter => "=",
                KeyCode.VcNumPadEnter => "=",
                KeyCode.VcF1 => "MC",
                KeyCode.VcF2 => "MR",
                KeyCode.VcF3 => "M+",
                KeyCode.VcF4 => "M-",
                KeyCode.VcF5 => "MS",
                _ => "$"
            };
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
                        Result = result.ErrorType switch {
                            CalculationErrorType.DivisionByZeroErrorInIndex => "Division By Zero",
                            CalculationErrorType.DivisionByZeroError => "Division By Zero",
                            CalculationErrorType.NoRealSolutionError => "No Real Solution",
                            CalculationErrorType.SyntaxError => "Syntax Error",
                            CalculationErrorType.OverflowError => "Overflow Error",
                            CalculationErrorType.NotNaturalExponentError => "Non-Natural Exponent",
                            CalculationErrorType.NotNaturalFactorialError => "Non-Natural Factorial"
                        };
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
