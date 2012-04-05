using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Modules.Orders.PresentationModels;
using Cabal.Client.Modules.Orders.Views;
using Cabal.Client.Test.Infrastructure;
using NUnit.Framework;

namespace Cabal.Client.Test.PresentationModels
{
    public class WeaponsPresentationModelFixture : PresentationModelFixture<IWeaponsView>
    {
        private WeaponsPresentationModel model;

        public override void SetUp()
        {
            base.SetUp();
            EventAggregator.Setup(ea => ea.GetEvent<GameSelectedEvent>()).Returns(new GameSelectedEvent());
            model = new WeaponsPresentationModel(MockView.Object, EventAggregator.Object, new MockGlobalRegions());
        }

        [Test]
        public void Show_Status()
        {
            SubscribeToEvent<ShowWeaponsStatusEvent, object>(o=>{});
            model.ShowStatus();
            VerifyEventRaised<ShowWeaponsStatusEvent>();
        }
    }
}
