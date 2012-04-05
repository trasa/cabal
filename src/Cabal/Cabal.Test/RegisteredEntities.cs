using System.Collections.Generic;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test
{
    public class RegisteredEntities
    {
        private readonly List<object> loadedObjects = new List<object>();


        public RegisteredEntities(ISession currentSession)
        {
            CurrentSession = currentSession;
        }

        private ISession CurrentSession { get; set; }

        public void AssertThatLoadedObjectsHaveIdentifier()
        {
            foreach (var entity in loadedObjects)
            {
                // get the "Id" getter
                var id = (int)(entity.GetType().GetProperty("Id").GetGetMethod().Invoke(entity, new object[0]));
                Assert.That(id, Is.Not.EqualTo(0));
            }
        }

        public IEnumerable<object> LoadedObjects { get { return loadedObjects; } }

        public T Load<T>(T o)
        {
            CurrentSession.Save(o);
            loadedObjects.Add(o);
            return o;
        }
    }
}
