namespace CalculatorDesktopApp
{
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
            window.MinimumHeight = 500;
            window.Width = 270;
            window.MinimumWidth = 270;
            window.Y = 20;
            window.X = 20;
            return window;
        }
    }
}