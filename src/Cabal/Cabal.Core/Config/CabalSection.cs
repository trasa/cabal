using System.Configuration;

namespace Cabal.Core.Config
{
    public class CabalSection : ConfigurationSection
    {
        [ConfigurationProperty("server")]
        public ServerElement Server
        {
            get { return (ServerElement)this["server"]; }
            set { this["server"] = value; }
        }

    }
}
