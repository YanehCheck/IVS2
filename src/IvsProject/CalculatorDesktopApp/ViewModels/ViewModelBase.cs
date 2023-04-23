using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalculatorDesktopApp.Services.Interfaces;

namespace CalculatorDesktopApp.ViewModels
{
    public abstract class ViewModelBase : ObservableRecipient, IViewModel
    {
        private bool _isRefreshRequired = true;
        protected readonly IMessengerService MessengerService;

        protected ViewModelBase(IMessengerService messengerService) 
            : base(messengerService.Messenger)
        {
            this.MessengerService = messengerService;
            IsActive = true;
        }

        public async Task OnAppearingAsync()
        {
            if (_isRefreshRequired)
            {
                await LoadDataAsync();
                _isRefreshRequired = false;
            }
        }
        protected virtual Task LoadDataAsync()
            => Task.CompletedTask;
    }
}