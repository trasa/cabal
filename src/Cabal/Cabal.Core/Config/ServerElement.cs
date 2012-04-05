using System.Configuration;

namespace Cabal.Core.Config
{
    public class ServerElement : ConfigurationElement
    {
        [ConfigurationProperty("cpuPlayerId")]
        public int CpuPlayerId
        {
            get { return (int)this["cpuPlayerId"]; }
            set { this["cpuPlayerId"] = value; }
        }
    }
}
