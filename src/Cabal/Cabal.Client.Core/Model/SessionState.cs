using Cabal.Core.Shared.Model;

namespace Cabal.Client.Core.Model
{
    public class SessionState
    {
        public string AuthToken { get; set; }
        public GameDto Game { get; set; }
        public string UserName { get; set; }
    }
}
