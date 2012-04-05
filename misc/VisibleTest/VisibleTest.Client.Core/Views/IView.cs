using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisibleTest.Client.Core.Views
{
    public interface IView<TModel>
    {
        TModel Model { get; set; }
    }
}
