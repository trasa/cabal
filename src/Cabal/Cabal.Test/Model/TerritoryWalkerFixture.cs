using System;
using System.Collections.Generic;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    public class TerritoryWalker
    {
        private readonly Dictionary<Territory, bool> visited = new Dictionary<Territory, bool>();

        

        public List<Territory> Walk()
        {
            Territory startingPoint = BuildVisitedDictionary();
            
            // starting with the 1st territory, walk to its neighbors.  continue until theres nobody left.
            Visit(startingPoint);
            var orphans = new List<Territory>();
            foreach(var pair in visited)
            {
                if (pair.Value == false)
                {
                    // we did NOT visit this territory...oops.
                    orphans.Add(pair.Key);
                }
            }
            return orphans;
        }

        private void Visit(Territory t)
        {
            visited[t] = true;
            foreach(Territory neighbor in t.Neighbors)
            {
                if (!visited[neighbor])
                {
                    Visit(neighbor);
                }
            }
        }



        private Territory BuildVisitedDictionary()
        {
            Territory startingPoint = null;
            bool first = true;
            foreach (Territory t in Territory.GetAllTerritories())
            {
                if (first)
                {
                    startingPoint = t;
                    first = false;
                }
                visited.Add(t, false);
            }
            return startingPoint;
        }
    }

    [TestFixture]
    public class TerritoryWalkerFixture
    {
        private TerritoryWalker walker;
        [SetUp]
        public void SetUp()
        {
            walker = new TerritoryWalker();
            List<Territory> orphans = walker.Walk();
            foreach(var t in orphans)
            {
                Console.WriteLine(t.Name);
            }
            Assert.That(orphans, Is.Empty);

        }

        [Test]
        public void Find_Territories()
        {
            IEnumerable<Territory> territories = Territory.GetAllTerritories();
            Assert.That(territories, Is.Not.Null);
            Assert.That(territories, Is.Not.Empty);
        }


    }
}
