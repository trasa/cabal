using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cabal.Client.Core.PresentationModels
{
    public interface IPresentationModel<TView>
    {
        TView View { get; }
    }
}
