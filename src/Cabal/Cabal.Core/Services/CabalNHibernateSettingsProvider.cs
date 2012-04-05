using Blackfin.Core.NHibernate;
using Blackfin.Core.NHibernate.Fluent;
using Cabal.Core.Model;
using FluentNHibernate.Cfg;

namespace Cabal.Core.Services
{
    public class CabalNHibernateSettingsProvider : INHibernateSettingsProvider
    {
        public CabalNHibernateSettingsProvider()
        {
            DatabaseType = SupportedDatabases.MsSql;
        }

        public void FluentlyConfigureMap(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<Game>();
        }

        public FluentConfiguration FluentlyConfigure(FluentConfiguration config)
        {
            return config;
        }

        public SupportedDatabases DatabaseType { get; set; }

        public string ConnectionStringKeyName
        {
            get { return "cabal"; }
        }

        public bool ShowSql
        {
            get { return true; }
        }

        public int BatchSize
        {
            get { return 32; }
        }

        public bool GenerateStatistics
        {
            get { return true; }
        }

        
    }
}
