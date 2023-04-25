using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorDesktopApp;
using CalculatorDesktopApp.Services.Interfaces;
using CalculatorDesktopApp.ViewModels;

namespace DigitObliterator.ViewModels
{
    /// <summary>
    /// ViewModel for Help
    /// </summary>
    public class HelpViewModel : ViewModelBase
    {
        /// <summary>
        /// Path to html help file
        /// </summary>
        public string HelpSource { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="HelpViewModel"/> type.
        /// </summary>
        /// <param name="messengerService"> Sending messages between ViewModels. </param>
        public HelpViewModel(IMessengerService messengerService) : base(messengerService)
        {
            if (Settings.Theme.QuestionMarkSource == "qm_white.png")
            {
                HelpSource = "dark.html";
            }
            else
            {
                HelpSource = "light.html";
            }
        }
    }
}
