using Cabal.Core.Shared.Model;
using Microsoft.Practices.Composite.Presentation.Events;

namespace Cabal.Client.Core.Infrastructure
{
    /// <summary>
    /// A Territory on the Board was selected.
    /// </summary>
    public class TerritorySelectedEvent : CompositePresentationEvent<TerritoryStateDto> {}

    /// <summary>
    /// A Game in the login screen was selected.
    /// </summary>
    public class GameSelectedEvent : CompositePresentationEvent<int> {}

    /// <summary>
    /// Request to display the current Weapons Development Status.
    /// </summary>
    public class ShowWeaponsStatusEvent : CompositePresentationEvent<object>{}
}
