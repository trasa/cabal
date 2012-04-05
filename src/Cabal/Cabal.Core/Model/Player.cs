using Blackfin.Core.Model;

namespace Cabal.Core.Model
{
    public class Player : Entity<Player>
    {
        public virtual string UserName { get; set; }

        public virtual bool IsCpu { get { return string.IsNullOrEmpty(UserName); } }

        public static string GetDisplayName(Player player, Player currentPlayer)
        {
            // TODO: this should be moved to a helper or something, doesn't belong in the model.
            if (player == null)
                return "Open";
            if (player.IsCpu)
                return "CPU";
            string userName = player.UserName;
            if (player.Equals(currentPlayer))
                userName += " [You!]";
            return userName;
        }
    }
}
