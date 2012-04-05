using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Blackfin.Core.Model;
using Cabal.Core.Shared.Exceptions;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Model
{
    public class Game : Entity<Game>, IGame
    {
        public Game()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            TerritoryStates = new Dictionary<int, TerritoryState>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual Player Owner { get; set; }

        public virtual Player SovietPlayer { get; set; }
        public virtual Player GermanPlayer { get; set; }
        public virtual Player BritishPlayer { get; set; }
        public virtual Player JapanesePlayer { get; set; }
        public virtual Player AmericanPlayer { get; set; }

        public virtual int SovietIpcAmount { get; set; }
        public virtual int GermanIpcAmount { get; set; }
        public virtual int BritishIpcAmount { get; set; }
        public virtual int JapaneseIpcAmount { get; set; }
        public virtual int AmericanIpcAmount { get; set; }

        public virtual int SovietIncome { get; set; }
        public virtual int GermanIncome { get; set; }
        public virtual int BritishIncome { get; set; }
        public virtual int JapaneseIncome { get; set; }
        public virtual int AmericanIncome { get; set; }

        #region SuperWeapons Flags
        public virtual bool SovietJetFighters { get; set; }
        public virtual bool SovietRockets { get; set; }
        public virtual bool SovietSuperSubs { get; set; }
        public virtual bool SovietLongRangeAir { get; set; }
        public virtual bool SovietIndustrialTech { get; set; }
        public virtual bool SovietHeavyBombers { get; set; }

        public virtual bool GermanJetFighters { get; set; }
        public virtual bool GermanRockets { get; set; }
        public virtual bool GermanSuperSubs { get; set; }
        public virtual bool GermanLongRangeAir { get; set; }
        public virtual bool GermanIndustrialTech { get; set; }
        public virtual bool GermanHeavyBombers { get; set; }

        public virtual bool BritishJetFighters { get; set; }
        public virtual bool BritishRockets { get; set; }
        public virtual bool BritishSuperSubs { get; set; }
        public virtual bool BritishLongRangeAir { get; set; }
        public virtual bool BritishIndustrialTech { get; set; }
        public virtual bool BritishHeavyBombers { get; set; }

        public virtual bool JapaneseJetFighters { get; set; }
        public virtual bool JapaneseRockets { get; set; }
        public virtual bool JapaneseSuperSubs { get; set; }
        public virtual bool JapaneseLongRangeAir { get; set; }
        public virtual bool JapaneseIndustrialTech { get; set; }
        public virtual bool JapaneseHeavyBombers { get; set; }

        public virtual bool AmericanJetFighters { get; set; }
        public virtual bool AmericanRockets { get; set; }
        public virtual bool AmericanSuperSubs { get; set; }
        public virtual bool AmericanLongRangeAir { get; set; }
        public virtual bool AmericanIndustrialTech { get; set; }
        public virtual bool AmericanHeavyBombers { get; set; }

        #endregion


        public virtual Player CurrentPlayer
        {
            get
            {
                return GetPlayerFor(CurrentNationality);
            }
        }


        public virtual Nationality CurrentNationality { get; protected set; }

        public virtual Player CreatedBy { get; set; }

        public virtual string Description { get; set; }
        public virtual bool IsStarted { get; protected set; }

        public virtual IDictionary<int, TerritoryState> TerritoryStates { get; set; }

        public virtual GameState GameState
        {
            get
            {
                if (!HasFullPlayers)
                {
                    return GameState.AcceptingPlayers;
                }
                if (!IsStarted)
                {
                    return GameState.StartPending;
                }
                // game is started.. is the game over?  TODO
                return GameState.PlayerTurn;
            }
        }

        public virtual bool HasFullPlayers
        {
            get
            {
                return AmericanPlayer != null &&
                       BritishPlayer != null &&
                       SovietPlayer != null &&
                       GermanPlayer != null &&
                       JapanesePlayer != null;
            }
        }

        public virtual IEnumerable<TerritoryStateDto> TerritoryStateDtos
        {
            get
            {
                return from ts in TerritoryStates.Values
                       select ts.ToDto();
            }
        }


        public virtual void Start(Player currentPlayer)
        {
            if (currentPlayer == null || !currentPlayer.Equals(Owner))
                throw new InvalidGameStateException("Only the Owner can start a game.");
            if (GameState != GameState.StartPending)
                throw new InvalidGameStateException("Game must be in StartPending state to be able to start a game.");

            var b = new GameBoard(this);
            b.Initialize();

            // starting income values:
            GermanIncome = 32;
            BritishIncome = 30;
            AmericanIncome = 36;
            SovietIncome = 24;
            JapaneseIncome = 25;

            // starting IPC balances: (2004 rules)
            SovietIpcAmount = 24;
            GermanIpcAmount = 40;
            BritishIpcAmount = 30;
            JapaneseIpcAmount = 30;
            AmericanIpcAmount = 42;

            IsStarted = true;
            CurrentNationality = Nationality.SovietUnion;
        }

        public virtual IEnumerable<Nationality> GetNationalityOf(Player player)
        {
            var result = new List<Nationality>();
            if (player.Equals(AmericanPlayer))
                result.Add(Nationality.UnitedStates);
            if (player.Equals(BritishPlayer))
                result.Add(Nationality.UnitedKingdom);
            if (player.Equals(SovietPlayer))
                result.Add(Nationality.SovietUnion);
            if (player.Equals(GermanPlayer))
                result.Add(Nationality.Germany);
            if (player.Equals(JapanesePlayer))
                result.Add(Nationality.Japan);
            return result;
        }

        public virtual Player GetPlayerFor(Nationality nationality)
        {
            switch (nationality)
            {
                case Nationality.SovietUnion:
                    return SovietPlayer;
                case Nationality.Germany:
                    return GermanPlayer;
                case Nationality.UnitedKingdom:
                    return BritishPlayer;
                case Nationality.Japan:
                    return JapanesePlayer;
                case Nationality.UnitedStates:
                    return AmericanPlayer;
                default:
                    return null;
            }
        }


        public virtual bool CanStart(Player currentPlayer)
        {
            if (currentPlayer == null || !currentPlayer.Equals(Owner))
                return false;
            if (GameState != GameState.StartPending)
                return false;

            return true;
        }

        public virtual TerritoryState GetTerritory(Territory territory)
        {
            TerritoryState t;
            if (!TerritoryStates.TryGetValue(territory.Id, out t))
            {
                t = new TerritoryState
                        {
                            Game = this,
                            TerritoryId = territory.Id,
                        };
                TerritoryStates.Add(t.TerritoryId, t);
            }
            return t;
        }

        public virtual TerritoryState GetTerritory(int territoryId)
        {
            Territory t = Territory.GetById(territoryId);
            return GetTerritory(t);
        }

        public virtual bool ContainsPlayer(Player player)
        {
            return Equals(SovietPlayer, player) ||
                   Equals(GermanPlayer, player) ||
                   Equals(BritishPlayer, player) ||
                   Equals(JapanesePlayer, player) ||
                   Equals(AmericanPlayer, player);
        }

        public virtual GameDto ToDto()
        {
            return Mapper.Map<Game, GameDto>(this);
        }
    }
}
