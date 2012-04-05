using NUnit.Framework;

namespace Cabal.Test.Shared
{
    public class ContextSpecification
    {
        [SetUp]
        public void SetUp()
        {
            Given();
            When();
            // Then(Asserts.Happen());
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        protected virtual void Given() { }
        protected virtual void When() { }
        protected virtual void CleanUp() { }

    }
}
