using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cabal.Core.Model;
using NUnit.Framework;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class UserStateFixture
    {
        private UserState state;

        [SetUp]
        public void SetUp()
        {
            state = new UserState { Roles = new List<string> { "test" } };
        }

        [Test]
        public void IsInRole_True()
        {
            Assert.IsTrue(state.IsInRole("test"));
        }

        [Test]
        public void IsInRole_False()
        {
            Assert.IsFalse(state.IsInRole("NOTtest"));
        }
    }
}
