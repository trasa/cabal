using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cabal.Core.Model;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace Cabal.Test.MappingFixtures
{
    [TestFixture]
    public class PlayerMapFixture : NHibernateSessionFixture
    {
        [Test]
        public void Verify()
        {
            new PersistenceSpecification<Player>(CurrentSession)
                .CheckProperty(x => x.UserName, "username")
                .VerifyTheMappings();
        }
    }
}
