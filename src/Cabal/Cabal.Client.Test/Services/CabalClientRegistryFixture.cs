using Cabal.Client.Core.Services;
using NUnit.Framework;
using StructureMap;

namespace Cabal.Client.Test.Services
{
    [TestFixture]
    public class CabalClientRegistryFixture
    {
        [Test]
        public void Verify()
        {
            ClientIoCContainer.Container = new Container();
            ClientIoCContainer.Configure().ForTest();
            ClientIoCContainer.Container.AssertConfigurationIsValid();
        }
    }
}
