using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.TerritoryStats.PresentationModels;
using Cabal.Client.Modules.TerritoryStats.Views;
using Cabal.Core.Shared.Model;
using Cabal.Test.Shared;
using Microsoft.Practices.Composite.Events;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.PresentationModels
{
    [TestFixture]
    public class When_Territory_Selected : ContextSpecification
    {
        private EventAggregator eventAggregator;
        private Mock<ITerritoryStatsView> view;
        private TerritoryStatsPresentationModel territoryStats;

        protected override void Given()
        {
            eventAggregator = new EventAggregator();
            view = new Mock<ITerritoryStatsView>();
            territoryStats = new TerritoryStatsPresentationModel(
                view.Object, eventAggregator);
        }

        protected override void When()
        {
            var state = new TerritoryStateDto
            {
                TerritoryId = Territory.Alaska.Id,
                ControlledBy = Nationality.UnitedStates,
            };
            eventAggregator.GetEvent<TerritorySelectedEvent>().Publish(state);
        }

        [Test]
        public void TerritoryName_Is_Updated()
        {
            Assert.That(territoryStats.TerritoryName, Is.EqualTo(Territory.Alaska.Name));
        }

        [Test]
        public void Ipc_Is_Updated()
        {
            Assert.That(territoryStats.TerritoryIpcValue, Is.EqualTo(Territory.Alaska.ManufacturingPoints));
        }

        [Test]
        public void ControlledBy_Is_Updated()
        {
            Assert.That(territoryStats.TerritoryControlledBy, Is.EqualTo(Nationality.UnitedStates));
        }

        [Test]
        public void ControlledByImageSource_Is_Updated()
        {
            Assert.That(territoryStats.TerritoryControlledByImageSource, Is.EqualTo(NationalityMarker.GetMarker(Nationality.UnitedStates)));
        }
    }
}
