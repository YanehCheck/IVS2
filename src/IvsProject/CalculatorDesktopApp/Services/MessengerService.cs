using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorDesktopApp.Services.Interfaces;
using CommunityToolkit.Mvvm.Messaging;

namespace CalculatorDesktopApp.Services
{
    public class MessengerService : IMessengerService
    {
        public IMessenger Messenger { get; }

        public MessengerService(IMessenger messenger)
        {
            Messenger = messenger;
        }

        public void Send<TMessage>(TMessage message)
            where TMessage : class
        {
            Messenger.Send(message);
        }
    }
}
