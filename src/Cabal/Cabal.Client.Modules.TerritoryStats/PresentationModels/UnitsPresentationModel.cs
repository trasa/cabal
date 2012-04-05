using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.TerritoryStats.Views;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Modules.TerritoryStats.PresentationModels
{
    public interface IUnitsPresentationModel : IPresentationModel<IUnitsView>
    {
        
    }


    public class UnitsPresentationModel : ViewModelBase<IUnitsView>, IUnitsPresentationModel
    {
        private Nationality armyNationality;
        private int infantry,
                    armor,
                    fighter,
                    bomber,
                    battleship,
                    carrier,
                    submarine,
                    transport,
                    antiaircraft,
                    industrialComplex;

        public UnitsPresentationModel()
        {
        }

        public UnitsPresentationModel(IUnitsView view, TerritoryStateArmyDto army)
        {
            View = view;
            view.Model = this;

            ArmyNationality = army.Nationality;
            Infantry = army.Infantry;
            Armor = army.Armor;
            Fighter = army.Fighters;
            Bomber = army.Bombers;
            Battleship = army.Battleships;
            Carrier = army.AircraftCarriers;
            Submarine = army.Submarines;
            Transport = army.Transports;
            Antiaircraft = army.Antiaircraft;
            IndustrialComplex = army.IndustrialComplexes;
        }


        public Nationality ArmyNationality
        {
            get { return armyNationality; }
            set
            {
                armyNationality = value;
                InvokePropertyChanged("ArmyNationality");
                InvokePropertyChanged("ArmyNationalityImageSource");
            }
        }

        public string ArmyNationalityImageSource
        {
            get { return NationalityMarker.GetMarker(ArmyNationality); }
        }
        

        public int Infantry
        {
            get { return infantry; }
            set { infantry = value; 
                InvokePropertyChanged("Infantry");
                InvokePropertyChanged("InfantryVisible");
            }
        }

        public Visibility InfantryVisible { get { return GetVisibility(Infantry); } }

        public int Armor
        {
            get { return armor; }
            set
            {
                armor = value; 
                InvokePropertyChanged("Armor");
                InvokePropertyChanged("ArmorVisible");
            }
        }
        
        public Visibility ArmorVisible { get { return GetVisibility(Armor); } }

        public int Fighter
        {
            get { return fighter; }
            set { fighter = value; 
                InvokePropertyChanged("Fighter");
                InvokePropertyChanged("FighterVisible");
            }
        }

        public Visibility FighterVisible { get { return GetVisibility(Fighter); } }

        public int Bomber
        {
            get { return bomber; }
            set { bomber = value; 
                InvokePropertyChanged("Bomber");
                InvokePropertyChanged("BomberVisible");
            }
        }

        public Visibility BomberVisible { get { return GetVisibility(Bomber); } }

        public int Battleship
        {
            get { return battleship;}
            set
            {
                battleship = value; 
                InvokePropertyChanged("Battleship");
                InvokePropertyChanged("BattleshipVisible");
            }
        }

        public Visibility BattleshipVisible { get { return GetVisibility(Battleship); } }

        public int Carrier
        {
            get { return carrier; }
            set { carrier = value; 
                InvokePropertyChanged("Carrier");
                InvokePropertyChanged("CarrierVisible");
            }
        }

        public Visibility CarrierVisible { get { return GetVisibility(Carrier); } }

        public int Submarine
        {
            get { return submarine; }
            set { submarine = value; 
                InvokePropertyChanged("Submarine");
                InvokePropertyChanged("SubmarineVisible");
            }
        }

        public Visibility SubmarineVisible { get { return GetVisibility(Submarine); } }

        public int Transport
        {
            get { return transport; }
            set { transport = value; 
                InvokePropertyChanged("Transport");
                InvokePropertyChanged("TransportVisible");
            }
        }

        public Visibility TransportVisible { get { return GetVisibility(Transport); } }

        public int Antiaircraft
        {
            get { return antiaircraft; }
            set { antiaircraft = value; 
                InvokePropertyChanged("Antiaircraft");
                InvokePropertyChanged("AntiaircraftVisible");
            }
        }

        public Visibility AntiaircraftVisible { get { return GetVisibility(Antiaircraft); } }

        public int IndustrialComplex
        {
            get { return industrialComplex; }
            set { industrialComplex = value; 
                InvokePropertyChanged("IndustrialComplex");
                InvokePropertyChanged("IndustrialComplexVisible"); 

            }
        }

        public Visibility IndustrialComplexVisible { get { return GetVisibility(IndustrialComplex); } }




        private static Visibility GetVisibility(int amount)
        {
            return amount > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}
