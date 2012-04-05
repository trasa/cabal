using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cabal.Core.Shared.Model
{
    public abstract class SoapTransportable : IExtensibleDataObject, INotifyPropertyChanged
    {
        [Browsable(false)]
        public ExtensionDataObject ExtensionData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
