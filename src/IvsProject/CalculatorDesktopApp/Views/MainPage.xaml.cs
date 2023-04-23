using CalculatorDesktopApp.ViewModels;
using CalculatorDesktopApp.Views;

namespace CalculatorDesktopApp
{
    public partial class MainPage : ContentPageBase
    {
        public MainPage(MainPageViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }

        private void Entered(object sender, PointerEventArgs e)
        {
            ((Button)sender).BackgroundColor = Settings.Theme.ButtonElseHoverColor;
        }

        private void Exited(object sender, PointerEventArgs e)
        {
            ((Button)sender).SetBinding(Button.BackgroundColorProperty, new Binding("Theme.ButtonElseColor"));
        }

        private void EnteredNumber(object sender, PointerEventArgs e)
        {
            ((Button)sender).BackgroundColor = Settings.Theme.ButtonNumbersHoverColor;
        }

        private void ExitedNumber(object sender, PointerEventArgs e)
        {
            ((Button)sender).SetBinding(Button.BackgroundColorProperty, new Binding("Theme.ButtonNumbersColor"));
        }

        private void EnteredEqual(object sender, PointerEventArgs e)
        {
            ((Button)sender).BackgroundColor = Settings.Theme.ButtonEqualHoverColor;
        }

        private void ExitedEqual(object sender, PointerEventArgs e)
        {
            ((Button)sender).SetBinding(Button.BackgroundColorProperty, new Binding("Theme.ButtonEqualColor"));
        }
    }
}