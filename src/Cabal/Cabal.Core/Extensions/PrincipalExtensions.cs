using System.Security.Principal;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using StructureMap;

namespace Cabal.Core.Extensions
{
    public static class PrincipalExtensions
    {
        public static Player GetPlayer(this IPrincipal u)
        {
            string name = u.GetName();
            if (string.IsNullOrEmpty(name))
                return null;
            return ObjectFactory.GetInstance<IPlayerRepository>().GetByName(name);
        }

        public static string GetName(this IPrincipal u)
        {
            if (u == null || u.Identity == null)
                return null;
            return u.Identity.Name;
        }
    }
}
