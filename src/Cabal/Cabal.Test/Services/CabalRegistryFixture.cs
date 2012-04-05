using Blackfin.Core.NUnit;
using Cabal.Core.Repositories;
using Cabal.Core.Services;
using NUnit.Framework;
using StructureMap;

namespace Cabal.Test.Services
{
    [TestFixture]
    public class CabalRegistryFixture
    {
        [SetUp]
        public void SetUp()
        {
            IoCContainer.Configure().ForTest();
        }

        [TearDown]
        public void TearDown()
        {
            ObjectFactory.Initialize(x => { });
            Expect.Exception<StructureMapException>(() => ObjectFactory.GetInstance<IPlayerRepository>());
        }

        [Test]
        public void Verify()
        {
            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}
