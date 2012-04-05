using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Core.Infrastructure
{
    public interface IGlobalRegions
    {
        IRegion MainRegion { get; }
        IRegion BottomPanelRegion { get; }
        IRegion PopupRegion { get; }
    }

    public class GlobalRegions : IGlobalRegions
    {
        private readonly IRegionManager regionManager;

        public GlobalRegions(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public IRegion MainRegion { get { return regionManager.Regions["MainRegion"]; } }
        public IRegion BottomPanelRegion { get { return regionManager.Regions["BottomPanelRegion"]; } }
        public IRegion PopupRegion { get { return regionManager.Regions["PopupRegion"]; } }
        
    }
}
