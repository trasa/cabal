using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Model;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Modules.Orders.Views;
using Cabal.Core.Shared.Model;
using Microsoft.Practices.Composite.Events;

namespace Cabal.Client.Modules.Orders.PresentationModels
{
    public interface IWeaponsStatusPresentationModel : IPresentationModel<IWeaponsStatusView>
    {
        
    }

    public class WeaponsStatusPresentationModel : ViewModelBase<IWeaponsStatusView>, IWeaponsStatusPresentationModel
    {
        private readonly IGlobalRegions globalRegions;
        private readonly SessionState sessionState;
        private PurchasedWeapons weapons;

        public WeaponsStatusPresentationModel()
        {
        }

        public WeaponsStatusPresentationModel(IWeaponsStatusView view, IEventAggregator eventAggregator, IGlobalRegions globalRegions, SessionState sessionState)
        {
            this.globalRegions = globalRegions;
            this.sessionState = sessionState;
            View = view;
            View.Model = this;
            eventAggregator.GetEvent<GameSelectedEvent>().Subscribe(OnGameSelected);
            eventAggregator.GetEvent<ShowWeaponsStatusEvent>().Subscribe(OnShowWeaponsStatus);
        }

        private void OnGameSelected(int gameId)
        {
            GameDto g = sessionState.Game;
            weapons = new PurchasedWeapons(g);
            InvokePropertyChanged("JetPower_Soviet");
            InvokePropertyChanged("JetPower_Germany");
            InvokePropertyChanged("JetPower_UnitedKingdom");
            InvokePropertyChanged("JetPower_Japan");
            InvokePropertyChanged("JetPower_USA");

            InvokePropertyChanged("Rockets_Soviet");
            InvokePropertyChanged("Rockets_Germany");
            InvokePropertyChanged("Rockets_UnitedKingdom");
            InvokePropertyChanged("Rockets_Japan");
            InvokePropertyChanged("Rockets_USA");

            InvokePropertyChanged("SuperSubs_Soviet");
            InvokePropertyChanged("SuperSubs_Germany");
            InvokePropertyChanged("SuperSubs_UnitedKingdom");
            InvokePropertyChanged("SuperSubs_Japan");
            InvokePropertyChanged("SuperSubs_USA");

            InvokePropertyChanged("LongRangeAir_Soviet");
            InvokePropertyChanged("LongRangeAir_Germany");
            InvokePropertyChanged("LongRangeAir_UnitedKingdom");
            InvokePropertyChanged("LongRangeAir_Japan");
            InvokePropertyChanged("LongRangeAir_USA");

            InvokePropertyChanged("IndustrialTech_Soviet");
            InvokePropertyChanged("IndustrialTech_Germany");
            InvokePropertyChanged("IndustrialTech_UnitedKingdom");
            InvokePropertyChanged("IndustrialTech_Japan");
            InvokePropertyChanged("IndustrialTech_USA");

            InvokePropertyChanged("HeavyBombers_Soviet");
            InvokePropertyChanged("HeavyBombers_Germany");
            InvokePropertyChanged("HeavyBombers_UnitedKingdom");
            InvokePropertyChanged("HeavyBombers_Japan");
            InvokePropertyChanged("HeavyBombers_USA");

        }

        private void OnShowWeaponsStatus(object obj)
        {
            globalRegions.PopupRegion.Activate(View);

        }


        public bool JetPower_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.JetPower); }}
        public bool JetPower_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.JetPower); } } 
        public bool JetPower_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.JetPower); } }
        public bool JetPower_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.JetPower);} }
        public bool JetPower_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.JetPower); } }


        public bool Rockets_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.Rockets); } }
        public bool Rockets_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.Rockets); } }
        public bool Rockets_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.Rockets); } }
        public bool Rockets_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.Rockets); } }
        public bool Rockets_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.Rockets); } }

        public bool SuperSubs_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.SuperSubs); } }
        public bool SuperSubs_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.SuperSubs); } }
        public bool SuperSubs_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.SuperSubs); } }
        public bool SuperSubs_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.SuperSubs); } }
        public bool SuperSubs_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.SuperSubs); } }

        public bool LongRangeAir_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.LongRangeAir); } }
        public bool LongRangeAir_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.LongRangeAir); } }
        public bool LongRangeAir_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.LongRangeAir); } }
        public bool LongRangeAir_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.LongRangeAir); } }
        public bool LongRangeAir_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.LongRangeAir); } }

        public bool IndustrialTech_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.IndustrialTech); } }
        public bool IndustrialTech_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.IndustrialTech); } }
        public bool IndustrialTech_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.IndustrialTech); } }
        public bool IndustrialTech_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.IndustrialTech); } }
        public bool IndustrialTech_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.IndustrialTech); } }

        public bool HeavyBombers_Germany { get { return weapons.Purchased(Nationality.Germany, Weapon.HeavyBombers); } }
        public bool HeavyBombers_Soviet { get { return weapons.Purchased(Nationality.SovietUnion, Weapon.HeavyBombers); } }
        public bool HeavyBombers_UnitedKingdom { get { return weapons.Purchased(Nationality.UnitedKingdom, Weapon.HeavyBombers); } }
        public bool HeavyBombers_Japan { get { return weapons.Purchased(Nationality.Japan, Weapon.HeavyBombers); } }
        public bool HeavyBombers_USA { get { return weapons.Purchased(Nationality.UnitedStates, Weapon.HeavyBombers); } }

    }
}
