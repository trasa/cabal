using System.Web.Security;
using Cabal.Core.Model;
using Cabal.Core.Repositories;

namespace Cabal.Core.Services
{
    public interface IPlayerService
    {
        int MinPasswordLength { get; }
        MembershipCreateStatus CreatePlayer(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        bool ValidateUser(string userName, string password);
        CabalAuthenticationTicket Authenticate(string username, string password);
    }



    public class PlayerService : IPlayerService
    {
        private readonly IMembershipService membershipService;
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IMembershipService membershipService, IPlayerRepository playerRepository)
        {
            this.membershipService = membershipService;
            this.playerRepository = playerRepository;
        }

        public int MinPasswordLength { get { return membershipService.MinPasswordLength; } }
        public MembershipCreateStatus CreatePlayer(string userName, string password, string email)
        {
            if (playerRepository.GetByName(userName) != null)
            {
                // oops already have a player with this name.
                return MembershipCreateStatus.DuplicateUserName;
            }
            MembershipCreateStatus result = membershipService.CreateUser(userName, password, email);
            
            if (result == MembershipCreateStatus.Success)
            {
                var p = new Player
                            {
                                UserName = userName
                            };
                playerRepository.Save(p);
            }
            return result;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return membershipService.ChangePassword(userName, oldPassword, newPassword);
        }

        public bool ValidateUser(string userName, string password)
        {
            return membershipService.ValidateUser(userName, password);
        }

        public CabalAuthenticationTicket Authenticate(string username, string password)
        {
            if (!ValidateUser(username, password))
            {
                return null;
                
            }
            var state = new UserState
                            {
                                UserName = username,
                                Roles = membershipService.GetRolesForUser(username)
                            };
            return new CabalAuthenticationTicket(state);
        }
    }
}
