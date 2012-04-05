using Blackfin.Core.Permit.Rules;
using Cabal.Core.Extensions;
using Cabal.Core.Model;
using Cabal.Core.Repositories;

namespace Cabal.Core.Rules
{
    public class PlayerBelongsToGame : Rule
    {
        private readonly IGameRepository gameRepository;

        public PlayerBelongsToGame(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public void Validate(RuleContext context)
        {
            Game g = gameRepository.Get(context.ParameterMap.GetValue<int>("gameId"));
            if (!g.ContainsPlayer(context.User.GetPlayer()))
            {
                throw new RuleException(string.Format("This Player ({0}) cannot participate in this Game ({1})",
                                                      context.User.Identity.Name,
                                                      g.Id));
            }
        }
    }
}
