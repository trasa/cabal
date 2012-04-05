using Cabal.Client.Core.Infrastructure;
using Microsoft.Practices.Composite.Regions;
using Moq;

namespace Cabal.Client.Test.Infrastructure
{
    public class MockGlobalRegions : IGlobalRegions
    {
        public MockGlobalRegions()
        {
            MockMainRegion = new Mock<IRegion>();
            MockPopupRegion = new Mock<IRegion>();
        }

        public Mock<IRegion> MockMainRegion { get; set; }
        public Mock<IRegion> MockPopupRegion { get; set; }
        public Mock<IRegion> MockBottomPanelRegion { get; set; }

        public IRegion MainRegion { get { return MockMainRegion.Object; } }
        public IRegion BottomPanelRegion { get { return MockBottomPanelRegion.Object;}}
        public IRegion PopupRegion { get { return MockPopupRegion.Object; } }
    }
}
