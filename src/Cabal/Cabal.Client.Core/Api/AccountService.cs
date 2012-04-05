using Cabal.Core.Shared.Model;

namespace Cabal.Client.Core.Api
{
    public interface IAccountService
    {
        string Login(string username, string password);
        GameDto[] GetActiveGames(string username);
    }

    public class AccountService : JsonService, IAccountService
    {
        public string Login(string username, string password)
        {
            var client = GetClient<string>("Account/Authenticate");
            return client.Post(new AuthenticationRequest(username, password));
        }

        public GameDto[] GetActiveGames(string username)
        {
            var client = GetClient<GameDto[]>("ListJson/active/" + username);
            return client.Get();
        }
    }
}
