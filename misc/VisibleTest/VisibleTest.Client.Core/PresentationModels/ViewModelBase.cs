using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace VisibleTest.Client.Core.PresentationModels
{
    public interface IPresentationModel<TView>
    {
        TView View { get; }
    }

    public abstract class ViewModelBase<TView> : INotifyPropertyChanged, IPresentationModel<TView>
    {
        protected ViewModelBase()
        {
            WireUpEvents();
        }

        protected static Visibility GetPanelVisibleState(bool isVisible)
        {
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }


        protected virtual void WireUpEvents()
        {
            // no events here.
        }

        protected void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null) h(this, e);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public TView View
        {
            get;
            protected set;
        }
    }
}
