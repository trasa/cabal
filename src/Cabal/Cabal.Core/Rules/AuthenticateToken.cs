using System.Web;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Model;

namespace Cabal.Core.Rules
{
    public class AuthenticateToken : Rule
    {
        private readonly HttpContextBase httpContext;

        public AuthenticateToken(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public void Validate(RuleContext context)
        {
            var authToken = context.ParameterMap.GetValue<string>("authToken");
            CabalAuthenticationTicket ticket = CabalAuthenticationTicket.Verify(authToken);
            httpContext.User = ticket.GetUser();
        }
    }
}
