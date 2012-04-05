using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace VisibleTest.Client.Core.Infrastructure
{
    public static class GlobalCommands
    {
        public static CompositeCommand RefreshMapCommand = new CompositeCommand();
    }

    public class GlobalCommandsProxy
    {
        public virtual CompositeCommand RefreshMapCommand { get { return GlobalCommands.RefreshMapCommand; } }
    }
}
