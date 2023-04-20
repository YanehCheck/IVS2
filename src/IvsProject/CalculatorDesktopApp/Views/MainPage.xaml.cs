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
    }
}