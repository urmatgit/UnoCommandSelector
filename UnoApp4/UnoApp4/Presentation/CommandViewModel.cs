using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp4.Presentation
{
    public partial class CommandViewModel: ObservableObject
    {
        INavigator _navigator;
        public CommandViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
