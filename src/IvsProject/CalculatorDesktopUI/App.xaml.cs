namespace CalculatorDesktopUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.Height = 650;
        window.MinimumHeight = 650;
        window.Width = 325;
        window.MinimumWidth = 325;
        window.Y = 20;
        window.X = 20;
        return window;
    }
}
