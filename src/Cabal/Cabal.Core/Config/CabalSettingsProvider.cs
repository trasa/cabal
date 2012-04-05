using System.Configuration;

namespace Cabal.Core.Config
{

    public interface ICabalSettingsProvider
    {
        CabalSection CabalSection { get; }
    }

    public class CabalSettingsProvider : ICabalSettingsProvider
    {
        private static readonly CabalSection cabalSection = (CabalSection)ConfigurationManager.GetSection("cabal");

        public CabalSection CabalSection {get{ return cabalSection;}}
    }


    public class StubCabalSettingsProvider : ICabalSettingsProvider
    {
        public StubCabalSettingsProvider()
        {
            
        }

        public StubCabalSettingsProvider(CabalSection cabalSection)
        {
            CabalSection = cabalSection;
        }

        public StubCabalSettingsProvider(int cpuPlayerId)
        {
            CabalSection = new CabalSection
                               {
                                   Server = new ServerElement
                                                {
                                                    CpuPlayerId = cpuPlayerId
                                                }
                               };
        }

        public CabalSection CabalSection { get; set; }
    }
}
