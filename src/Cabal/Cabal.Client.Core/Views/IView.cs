using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Cabal.Client.Core.Views
{
    public interface IView<TModel>
    {
        TModel Model { get; set; }
    }
}
