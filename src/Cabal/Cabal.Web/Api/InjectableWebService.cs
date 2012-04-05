using System.Web.Services;
using Cabal.Core.Model;
using StructureMap;

namespace Cabal.Web.Api
{
    public abstract class InjectableWebService : WebService
    {
        protected InjectableWebService()
        {
            ObjectFactory.BuildUp(this);
        }

        protected void Authenticate(string authToken)
        {
            CabalAuthenticationTicket ticket = CabalAuthenticationTicket.Verify(authToken);
            Context.User = ticket.GetUser();
        }
    }
}
