using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackfin.Core.NUnit;
using Cabal.Core.Model;
using NUnit.Framework;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class UserStateFixture_Serialize
    {
        private static void TestSerializeDeserialize(string serialized, UserState deserialized)
        {
            // Test Serialization
            Assert.AreEqual(serialized, deserialized.Serialize());

            // Test Deserialization
            var actual = UserState.Deserialize(serialized);
            Assert.AreEqual(deserialized.UserName, actual.UserName);
            AssertArray.AreEqual(deserialized.Roles.ToArray(), actual.Roles.ToArray());
        }


        [Test]
        public void AllFieldsHaveDataTest()
        {
            TestSerializeDeserialize(
                "jwalker|abc,def,ghi", 
                new UserState
                {
                    UserName = "jwalker",
                    Roles = new[] { "abc", "def", "ghi" }
                });
        }


        [Test]
        public void EmptyValuesShouldSerialize()
        {
            TestSerializeDeserialize(
                "|",
                new UserState
                {
                    UserName = string.Empty,
                    Roles = new string[0]
                });
        }
    }
}
