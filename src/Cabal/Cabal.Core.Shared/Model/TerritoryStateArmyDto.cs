using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Cabal.Core.Shared.Model
{

    [DebuggerStepThrough]
    [GeneratedCode("System.Runtime.Serialization", "3.0.0.0")]
    [DataContract(Name = "TerritoryStateArmyDto", Namespace = "http://meancat.com/")]
    [Serializable]
    public class TerritoryStateArmyDto : object, IExtensibleDataObject, INotifyPropertyChanged
    {
        private int AircraftCarriersField;
        private int AntiaircraftField;
        private int ArmorField;

        private int BattleshipsField;
        private int BombersField;

        [NonSerialized()]
        private ExtensionDataObject extensionDataField;
        
        private int FightersField;

        private int IndustrialComplexesField;
        private int InfantryField;
        private Nationality NationalityField;
        private int SubmarinesField;
        private int TerritoryIdField;
        private int TransportsField;

        [DataMember(IsRequired = true)]
        public int TerritoryId
        {
            get { return TerritoryIdField; }
            set
            {
                if ((TerritoryIdField.Equals(value) != true))
                {
                    TerritoryIdField = value;
                    RaisePropertyChanged("TerritoryId");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 1)]
        public Nationality Nationality
        {
            get { return NationalityField; }
            set
            {
                if ((NationalityField.Equals(value) != true))
                {
                    NationalityField = value;
                    RaisePropertyChanged("Nationality");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 2)]
        public int Infantry
        {
            get { return InfantryField; }
            set
            {
                if ((InfantryField.Equals(value) != true))
                {
                    InfantryField = value;
                    RaisePropertyChanged("Infantry");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 3)]
        public int Armor
        {
            get { return ArmorField; }
            set
            {
                if ((ArmorField.Equals(value) != true))
                {
                    ArmorField = value;
                    RaisePropertyChanged("Armor");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 4)]
        public int Fighters
        {
            get { return FightersField; }
            set
            {
                if ((FightersField.Equals(value) != true))
                {
                    FightersField = value;
                    RaisePropertyChanged("Fighters");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 5)]
        public int Bombers
        {
            get { return BombersField; }
            set
            {
                if ((BombersField.Equals(value) != true))
                {
                    BombersField = value;
                    RaisePropertyChanged("Bombers");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 6)]
        public int Antiaircraft
        {
            get { return AntiaircraftField; }
            set
            {
                if ((AntiaircraftField.Equals(value) != true))
                {
                    AntiaircraftField = value;
                    RaisePropertyChanged("Antiaircraft");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 7)]
        public int Battleships
        {
            get { return BattleshipsField; }
            set
            {
                if ((BattleshipsField.Equals(value) != true))
                {
                    BattleshipsField = value;
                    RaisePropertyChanged("Battleships");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 8)]
        public int AircraftCarriers
        {
            get { return AircraftCarriersField; }
            set
            {
                if ((AircraftCarriersField.Equals(value) != true))
                {
                    AircraftCarriersField = value;
                    RaisePropertyChanged("AircraftCarriers");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 9)]
        public int Transports
        {
            get { return TransportsField; }
            set
            {
                if ((TransportsField.Equals(value) != true))
                {
                    TransportsField = value;
                    RaisePropertyChanged("Transports");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 10)]
        public int Submarines
        {
            get { return SubmarinesField; }
            set
            {
                if ((SubmarinesField.Equals(value) != true))
                {
                    SubmarinesField = value;
                    RaisePropertyChanged("Submarines");
                }
            }
        }

        [DataMember(IsRequired = true, Order = 11)]
        public int IndustrialComplexes
        {
            get { return IndustrialComplexesField; }
            set
            {
                if ((IndustrialComplexesField.Equals(value) != true))
                {
                    IndustrialComplexesField = value;
                    RaisePropertyChanged("IndustrialComplexes");
                }
            }
        }

        #region IExtensibleDataObject Members

        [Browsable(false)]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionDataField; }
            set { extensionDataField = value; }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;


        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
