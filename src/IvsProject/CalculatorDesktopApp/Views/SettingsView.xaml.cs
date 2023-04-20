using CalculatorDesktopApp.ViewModels;

namespace CalculatorDesktopApp.Views;

public partial class SettingsView : ContentPageBase
{
	public SettingsView(SettingsViewModel viewModel) 
        : base(viewModel)
    {
        InitializeComponent();
	}
}