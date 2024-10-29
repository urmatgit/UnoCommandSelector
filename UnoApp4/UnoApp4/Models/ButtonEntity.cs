using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp4.Presentation;
public partial class ButtonEntityModel: ObservableObject
{
    public int Index { get; set; }

    public string Content { get; set; }
    [ObservableProperty]
    public bool isEnabled = true;
}
