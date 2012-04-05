using System;
using System.Collections.Generic;
using System.Web.Security;

namespace Cabal.Core.Services
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);

        IEnumerable<string> GetRolesForUser(string username);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider membershipProvider;
        private readonly RoleProvider roleProvider;
        
        public AccountMembershipService()
            : this(null, null)
        {
        }

        public AccountMembershipService(MembershipProvider membershipProvider, RoleProvider roleProvider)
        {
            this.membershipProvider = membershipProvider ?? Membership.Provider;
            this.roleProvider = roleProvider ?? Roles.Provider;
        }

        #region IMembershipService Members

        public int MinPasswordLength
        {
            get { return membershipProvider.MinRequiredPasswordLength; }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (password == null)
                throw new ArgumentNullException("password");
            return membershipProvider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            membershipProvider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser currentUser = membershipProvider.GetUser(userName, true /* userIsOnline */);
            return currentUser.ChangePassword(oldPassword, newPassword);
        }

        public IEnumerable<string> GetRolesForUser(string username)
        {
            return roleProvider.GetRolesForUser(username);
        }

        #endregion
    }
}