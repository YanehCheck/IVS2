using System;
using System.Globalization;
using CalculatorDesktopApp.Models;
using CommunityToolkit.Mvvm.Input;
using SharpHook.Reactive;
using SharpHook.Native;
using CalculatorDesktopApp.Messages;
using CalculatorDesktopApp.Services.Interfaces;
using CalculatorModel;
using CommunityToolkit.Mvvm.Messaging;

namespace CalculatorDesktopApp.ViewModels
{
    /// <summary>
    /// ViewModel for Calculator
    /// </summary>
    public partial class MainPageViewModel : ViewModelBase, IRecipient<DecimalPlacesMessage>, IRecipient<ThemeMessage>
    {
        /// <summary>
        /// Application theme.
        /// </summary>
        public ThemeModel Theme { get; set; }

        /// <summary>
        /// String representation of an expression.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Result of the expression.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Holds reference to <see cref="Calculator"/> instance.
        /// </summary>
        private Calculator Calculator { get; set; }

        /// <summary>
        /// Information about the last key pressed.
        /// </summary>
        private string LastKey { get; set; }

        /// <summary>
        /// The color of the expression result.
        /// </summary>
        public Color ResultColor { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="MainPageViewModel"/> type.
        /// </summary>
        /// <param name="messengerService"> Sending messages between ViewModels. </param>
        public MainPageViewModel(IMessengerService messengerService) : base(messengerService)
        {
            if (Preferences.ContainsKey("theme"))
            {
                var themePreference = Preferences.Get("theme", "dark");
                Settings.Theme = themePreference == "dark" ? ThemeModel.Dark : ThemeModel.Light;
            }
            else
            {
                Settings.Theme = ThemeModel.Dark;
                Preferences.Set("theme", "dark");
            }

            if (Preferences.ContainsKey("decimalPlaces"))
            {
                var decimalPlacesPreference = Preferences.Get("decimalPlaces", "5");
                Settings.DecimalPlaces = Convert.ToInt32(decimalPlacesPreference);
            }
            else
            {
                Settings.DecimalPlaces = 5;
                Preferences.Set("theme", "5");
            }

            Settings.DecimalPlaces = 5;
            Settings.Theme = ThemeModel.Dark;
            Calculator = new Calculator(Settings.DecimalPlaces);
            Theme = Settings.Theme;
            Expression = "";
            Result = "";
            LastKey = "$";

            // Asynchronous reading of pressed keys
            var hook = new SimpleReactiveGlobalHook();
            // The OnKeyDown method subscribe the key press
            hook.KeyPressed.Subscribe(e => OnKeyDown(e.Data.KeyCode));
            hook.RunAsync();
        }

        /// <summary>
        /// Converts the KeyCode to the corresponding string representation.
        /// </summary>
        /// <param name="keyCode"> The code of the button that was pressed. </param>
        /// <returns> <see cref="string"/> </returns>
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

        /// <summary>
        /// A method that handles a keypress event
        /// </summary>
        /// <param name="keyCode"></param>
        private void OnKeyDown(KeyCode keyCode)
        {
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

        /// <summary>
        /// Asynchronously copies the calculation result to the user's clipboard.
        /// </summary>
        public async void CopyResultToClipboard()
        {
            if (Application.Current != null)
                await Application.Current.Dispatcher.DispatchAsync(() => { Clipboard.SetTextAsync(Result); });
        }

        /// <summary>
        /// Command that responds to button presses on the calculator.
        /// </summary>
        /// <param name="bindingContext"> A string representation of a particular button. </param>
        [RelayCommand]
        private void ButtonPressed(string bindingContext)
        {
            switch (bindingContext)
            {
                // Remove a value from the top of the stack
                case "MC":
                {
                    Calculator.Memory.MC();
                    break;
                }
                // Reads a value from the stack and adds it to an expression
                case "MR":
                {
                    Expression += Convert.ToString(Calculator.Memory.MR(), CultureInfo.InvariantCulture);
                    break;
                }
                // Add the result to the top value of the stack
                case "M+":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MPlus(Convert.ToDecimal(Result));
                    }
                    break;
                }
                // Subtracts the result from the top value of the stack
                case "M-":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MMinus(Convert.ToDecimal(Result));
                    }
                    break;
                }
                // Stores a new value on the stack (from the result of the enumeration)
                case "MS":
                {
                    if (!string.IsNullOrWhiteSpace(Result))
                    {
                        Calculator.Memory.MS(Convert.ToDecimal(Result));
                    }
                    break;
                }
                // Delete the last character of the expression
                case "CE":
                {
                    Result = "";
                    if (Expression.Length >= 1) Expression = Expression[..^1];
                    break;
                }
                // Adds a decimal point to the end of an expression
                case "•":
                {
                    Result = "";
                    Expression += ".";
                    break;
                }
                // Tries to evaluate the expression
                case "=":
                {
                    Result = "";
                    // An empty expression will not be evaluated
                    if (string.IsNullOrWhiteSpace(Expression))
                    {
                        return;
                    }

                    // Converting some characters to others for the parser and then trying to enumerate
                    var result = Calculator.Calculate(Expression
                        .Replace(",",".")
                        .Replace("÷", "/")
                        .Replace("x", "*"));

                    // If it was calculated successfully, the result will be printed
                    if (result.ErrorType == CalculationErrorType.None)
                    {
                        ResultColor = Theme.ResultOk;
                        Result = Convert.ToString(result.Value, CultureInfo.InvariantCulture);
                    }
                    // Otherwise, information about a specific error will be displayed
                    else
                    {
                        ResultColor = Theme.ResultError;
                        Result = result.ErrorType switch
                        {
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
                // Other characters will be appended to the end of the expression
                default:
                {
                    Result = "";
                    Expression += bindingContext;
                    break;
                }
            }
        }

        /// <summary>
        /// Navigates the user to the settings page.
        /// </summary>
        /// <returns> A <see cref="Task"/> representing the asynchronous operation of navigating to the settings page. </returns>
        [RelayCommand]
        private async Task GoToSettingsAsync()
        {
            await Shell.Current.GoToAsync("settings");
        }

        /// <summary>
        /// Navigates the user to the help page.
        /// </summary>
        /// <returns> A <see cref="Task"/> representing the asynchronous operation of navigating to the help page. </returns>
        [RelayCommand]
        private async Task GoToHelpAsync()
        {
            await Shell.Current.GoToAsync("help");
        }

        /// <summary>
        /// Decimal place change report.
        /// </summary>
        /// <param name="message"> A message about decimal place change. </param>
        public void Receive(DecimalPlacesMessage message)
        {
            // Create a new Calculator instance with information about the required decimal places
            Calculator = new Calculator(Settings.DecimalPlaces);
        }

        /// <summary>
        /// Theme model change report.
        /// </summary>
        /// <param name="message"> A message about application theme change. </param>
        public void Receive(ThemeMessage message)
        {
            Theme = Settings.Theme;
        }
    }
}
