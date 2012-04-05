using System;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Web.Security;

namespace Cabal.Core.Model
{
    public class CabalAuthenticationTicket
    {
        private readonly FormsAuthenticationTicket ticket;

        private CabalAuthenticationTicket(FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
            UserState = UserState.Deserialize(ticket.UserData);
        }

        public CabalAuthenticationTicket(UserState state)
        {
            UserState = state;
            ticket = new FormsAuthenticationTicket(
                1,            // version
                state.UserName,     // auth name (userid)0
                DateTime.Now, // issued date
                DateTime.Now.AddMinutes(60 * 4), // expires
                false,          // isPersistent
                state.Serialize());      // serialized UserState (can not be null) 
        }

        public bool Expired { get { return ticket.Expired; } }

        public UserState UserState { get; private set; }


        public string Encrypt()
        {
            return FormsAuthentication.Encrypt(ticket);
        }

        public static CabalAuthenticationTicket Decrypt(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return null;
                }
                FormsAuthenticationTicket a = FormsAuthentication.Decrypt(value);
                return new CabalAuthenticationTicket(a);
            }
            catch
            {
                return null;
            }
        }

        public static CabalAuthenticationTicket Verify(string value)
        {
            CabalAuthenticationTicket ticket = Decrypt(value);
            if (ticket == null)
                throw new SecurityException("Failed to Verify Authentication Ticket.");
            if (ticket.Expired)
                throw new SecurityException("Ticket is expired.");
            return ticket;
        }

        public IPrincipal GetUser()
        {
            return new GenericPrincipal(new GenericIdentity(UserState.UserName), UserState.Roles.ToArray());
        }
    }
}
