using Cabal.Core.Services;
using NUnit.Framework;

namespace Cabal.Test.Services
{
    [TestFixture]
    public class AutoMapperConfigurationFixture
    {
        [Test]
        public void Configure()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}
