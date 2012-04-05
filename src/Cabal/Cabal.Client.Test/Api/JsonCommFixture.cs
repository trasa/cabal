using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using Cabal.Client.Core.Api;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.Api
{
    [TestFixture]
    public class JsonCommFixture
    {
        [Test]
        public void Authenticate()
        {
            var resetEvent = new AutoResetEvent(false);
            var proxy = new WebClientProxy<string>("http://localhost:16180/Account/Authenticate");
            string x = null;
            proxy.PostAsync(new AuthenticationRequest("admin", "admin"),
                       result =>
                           {
                               x = result;
                               resetEvent.Set();
                           });
               
            // get uses async and the test is very sync.
            resetEvent.WaitOne(10000);
            Assert.That(x, Is.Not.Null);
        }

        [Test]
        public void Serialize_An_Object()
        {
            var req = new AuthenticationRequest("user", "password");
            var serializer = new DataContractJsonSerializer(typeof(AuthenticationRequest));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, req);
            string s = new StreamReader(new MemoryStream(stream.GetBuffer())).ReadToEnd();
            Console.WriteLine("s is " + s);
        }
    }
}
