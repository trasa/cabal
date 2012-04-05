using Microsoft.Practices.Composite.Presentation.Commands;

namespace Cabal.Client.Core.Infrastructure
{
    public static class GlobalCommands
    {
        public static CompositeCommand RefreshMapCommand = new CompositeCommand();
        public static CompositeCommand ResetMapPanAndZoomCommand = new CompositeCommand();

        public static CompositeCommand LoginCommand = new CompositeCommand();
        public static CompositeCommand SelectActiveGameCommand = new CompositeCommand();
    }

    public interface IGlobalCommandsProxy
    {
        CompositeCommand RefreshMapCommand { get; }
        CompositeCommand ResetMapPanAndZoomCommand { get; }
        
        CompositeCommand LoginCommand { get; }
        CompositeCommand SelectActiveGameCommand { get; }
    }

    public class GlobalCommandsProxy : IGlobalCommandsProxy
    {
        public virtual CompositeCommand RefreshMapCommand { get { return GlobalCommands.RefreshMapCommand;}}
        public virtual CompositeCommand ResetMapPanAndZoomCommand { get { return GlobalCommands.ResetMapPanAndZoomCommand; } }

        public virtual CompositeCommand LoginCommand { get { return GlobalCommands.LoginCommand; } }
        public virtual CompositeCommand SelectActiveGameCommand {get { return GlobalCommands.SelectActiveGameCommand;}}
    }

    public class StubCommandsProxy : IGlobalCommandsProxy
    {
        public StubCommandsProxy()
        {
            RefreshMapCommand = new CompositeCommand();
            ResetMapPanAndZoomCommand = new CompositeCommand();
            LoginCommand = new CompositeCommand();
            SelectActiveGameCommand = new CompositeCommand();
        }

        public CompositeCommand RefreshMapCommand { get; private set; }
        public CompositeCommand ResetMapPanAndZoomCommand { get; private set; }
        public CompositeCommand LoginCommand { get; private set; }
        public CompositeCommand SelectActiveGameCommand { get; private set; }
    }
}
