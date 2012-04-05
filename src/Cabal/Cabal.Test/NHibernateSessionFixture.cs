using Blackfin.Core.Extensions;
using Blackfin.Core.NHibernate;
using Blackfin.Core.NHibernate.Fluent;
using Cabal.Core.Services;
using Cabal.Test.Shared;
using NHibernate;
using NUnit.Framework;

namespace Cabal.Test
{
    [TestFixture]
    public class NHibernateSessionFixture : NHibernateSessionFixtureBase
    {
        protected override INHibernateConfigurationService ConfigurationService
        {
            get { return new NHibernateConfigurationService(new CabalNHibernateSettingsProvider {DatabaseType = SupportedDatabases.InMemory}); }
        }

        protected override bool DoCreateSchema
        {
            get { return true; }
        }
    }

    public abstract class NHibernateSessionFixtureBase : ContextSpecification
    {
        private RegisteredEntities registeredEntities;

        protected abstract INHibernateConfigurationService ConfigurationService { get; }

        protected abstract bool DoCreateSchema { get; }

        protected NHibernateSession NHibernateSession { get; set; }

        protected override void Given()
        {
            base.Given();
            INHibernateConfigurationService config = ConfigurationService;
            NHibernateSession = new NHibernateSession(config.CreateSessionFactory(), new SimpleSessionStorage());

            if (DoCreateSchema)
            {
                config.CreateSchema(false, NHibernateSession.Current.Connection);
            }
            else
            {
                // HACK: init session
                NHibernateSession.Storage.Session = NHibernateSession.Current;
            }
            registeredEntities = new RegisteredEntities(CurrentSession);
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            NHibernateSession.Storage.Session.Dispose();
        }

        protected void FlushSession()
        {
            // Commits any changes up to this point to the database
            NHibernateSession.Storage.Session.Flush();
        }

        protected void Evict(object instance)
        {
            // Evicts the instance from the current session so that it can be loaded during testing;
            // this gives the test a clean slate, if you will, to work with
            NHibernateSession.Storage.Session.Evict(instance);
        }

        protected void FlushSessionAndEvict(object instance)
        {
            FlushSession();
            Evict(instance);
        }

        protected ISession CurrentSession { get { return NHibernateSession.Storage.Session; } }

        protected void EvictLoadedObjects()
        {
            registeredEntities.LoadedObjects.ForEach(Evict);
        }

        protected T Load<T>(T o)
        {
            return registeredEntities.Load(o);
        }

        protected void AssertThatLoadedObjectsHaveIdentifier()
        {
            registeredEntities.AssertThatLoadedObjectsHaveIdentifier();
        }
    }
}
