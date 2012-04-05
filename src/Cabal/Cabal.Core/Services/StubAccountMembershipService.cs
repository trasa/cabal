using System.Collections.Generic;
using System.Web.Security;

namespace Cabal.Core.Services
{
    public class StubAccountMembershipService : IMembershipService
    {
        #region IMembershipService Members

        public int MinPasswordLength
        {
            get { return 8; }
        }

        public bool ValidateUser(string userName, string password)
        {
            return true;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            return MembershipCreateStatus.Success;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return true;
        }

        public IEnumerable<string> GetRolesForUser(string username)
        {
            return new string[0];
        }

        #endregion
    }
}