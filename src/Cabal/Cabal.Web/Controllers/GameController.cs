using System.Web.Mvc;
using Blackfin.Core.Mvc.Controllers;
using Cabal.Core.Factories;
using Cabal.Core.Helpers;
using Cabal.Core.Model;
using Cabal.Core.Shared.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Services;

namespace Cabal.Web.Controllers
{
    [Authorize]
    public class GameController : SmartController
    {
        private readonly Player currentPlayer;
        private readonly IGameFactory gameFactory;
        private readonly IGameRepository gameRepository;
        private readonly IPlayerRepository playerRepository;


        public GameController(ICurrentPlayerProvider currentPlayerProvider,
            IGameFactory gameFactory, IGameRepository gameRepository,
            IPlayerRepository playerRepository)
        {
            currentPlayer = currentPlayerProvider.GetUserPlayer();
            this.gameRepository = gameRepository;
            this.gameFactory = gameFactory;
            this.playerRepository = playerRepository;
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Game/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Create(CreateGameViewModel game)
        {
            game.CurrentPlayer = currentPlayer;
            game.CpuPlayer = playerRepository.GetCpuPlayer();
            Game g = gameFactory.Create(game.CurrentPlayer,
                                        game.Description,
                                        game.GetSovietPlayer(),
                                        game.GetGermanPlayer(),
                                        game.GetBritishPlayer(),
                                        game.GetJapanesePlayer(),
                                        game.GetAmericanPlayer());
            gameRepository.Save(g);
            return ToAllGamesList();
        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id)
        {
            Game g = gameRepository.Get(id);
            if (g == null)
                return ToAllGamesList();

            var vm = new EditGameViewModel
                         {
                             Id = g.Id,
                             Description = g.Description,
                             CanStartGame = g.CanStart(currentPlayer),
                             OwnerDisplayName = Player.GetDisplayName(g.Owner, currentPlayer),
                             AmericanPlayerState = new EditGameViewModel.PlayerState(Nationality.UnitedStates, g.AmericanPlayer, currentPlayer),
                             SovietPlayerState = new EditGameViewModel.PlayerState(Nationality.SovietUnion, g.SovietPlayer, currentPlayer),
                             JapanesePlayerState = new EditGameViewModel.PlayerState(Nationality.Japan, g.JapanesePlayer, currentPlayer),
                             BritishPlayerState = new EditGameViewModel.PlayerState(Nationality.UnitedKingdom, g.BritishPlayer, currentPlayer),
                             GermanPlayerState = new EditGameViewModel.PlayerState(Nationality.Germany, g.GermanPlayer, currentPlayer),
                         };
            return View(vm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Edit(EditGameViewModel gameViewModel)
        {
            gameViewModel.CurrentPlayer = currentPlayer;
            gameViewModel.CpuPlayer = playerRepository.GetCpuPlayer();
            Game g = gameRepository.Get(gameViewModel.Id);
            if (g == null)
                return RedirectToAction<ListController>(c => c.Games("All", null));

            g.Description = gameViewModel.Description;

            if (gameViewModel.CanEdit(g.SovietPlayer))
            {
                g.SovietPlayer = gameViewModel.GetSovietPlayer();
            }
            if (gameViewModel.CanEdit(g.GermanPlayer))
            {
                g.GermanPlayer = gameViewModel.GetGermanPlayer();
            }
            if (gameViewModel.CanEdit(g.BritishPlayer))
            {
                g.BritishPlayer= gameViewModel.GetBritishPlayer();
            }
            if (gameViewModel.CanEdit(g.JapanesePlayer))
            {
                g.JapanesePlayer = gameViewModel.GetJapanesePlayer();
            }
            if (gameViewModel.CanEdit(g.AmericanPlayer))
            {
                g.AmericanPlayer = gameViewModel.GetAmericanPlayer();
            }
            gameRepository.Save(g);
            return ToAllGamesList();
        }

        public ActionResult Start(int id)
        {
            Game g = gameRepository.Get(id);
            if (g == null || !g.CanStart(currentPlayer))
            {
                return ToAllGamesList();
            }
            return View(new StartGameViewModel {Id = g.Id});
        }

        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Start(StartGameViewModel vm)
        {
            Game g = gameRepository.Get(vm.Id);
            if (g != null && g.CanStart(currentPlayer))
            {
                g.Start(currentPlayer);
                gameRepository.Save(g);
            }
            return ToAllGamesList();
        }

        private ActionResult ToAllGamesList()
        {
            return RedirectToAction<ListController>(c => c.Games("All", null), new { list = "All", id = "" });
        }
    }







    public class StartGameViewModel
    {
        public int Id { get; set;}
    }

    #region public class GameViewModel { ... }

    public class GameViewModel
    {
        public enum PlayerCpu { Self, Cpu, Open }
        public string Description { get; set; }
        public bool CanStartGame { get; set; }
        public string OwnerDisplayName { get; set; }

        public PlayerCpu SovietUnion { get; set; }
        public PlayerCpu Germany { get; set; }
        public PlayerCpu UnitedKingdom { get; set; }
        public PlayerCpu Japan { get; set; }
        public PlayerCpu UnitedStates { get; set; }

        public Player CurrentPlayer { get; set; }
        public Player CpuPlayer { get; set; }

        public Player GetSovietPlayer()
        {
            return GetPlayer(SovietUnion);
        }
        public Player GetGermanPlayer()
        {
            return GetPlayer(Germany);
        }
        public Player GetBritishPlayer()
        {
            return GetPlayer(UnitedKingdom);
        }
        public Player GetJapanesePlayer()
        {
            return GetPlayer(Japan);
        }
        public Player GetAmericanPlayer()
        {
            return GetPlayer(UnitedStates);
        }

        private Player GetPlayer(PlayerCpu p)
        {
            switch (p)
            {
                case PlayerCpu.Self:
                    return CurrentPlayer;

                case PlayerCpu.Cpu:
                    return CpuPlayer;

                default:
                    return null;
            }
        }

    }

    #endregion

    #region public class PlayerRadioButtonModel { ... }

    public class PlayerRadioButtonModel
    {
        public PlayerRadioButtonModel(Nationality nationality)
        {
            Nationality = nationality;
            IsOpen = true;
        }

        public Nationality Nationality { get; set; }
        public bool IsOpen { get; set; }
        public bool IsSelf { get; set; }
        public bool IsCpu { get; set; }
    }

    #endregion

    public class CreateGameViewModel : GameViewModel
    {

    }

    public class EditGameViewModel : GameViewModel
    {

        public int Id { get; set; }

        public PlayerState SovietPlayerState { get; set; }
        public PlayerState GermanPlayerState { get; set; }
        public PlayerState BritishPlayerState { get; set; }
        public PlayerState JapanesePlayerState { get; set; }
        public PlayerState AmericanPlayerState { get; set; }


        public class PlayerState
        {
            public PlayerState(Player player, Player currentPlayer) : this(Nationality.SovietUnion, player, currentPlayer)
            {
                
            }

            public PlayerState(Nationality nationality, Player player, Player currentPlayer)
            {
                Nationality = nationality;
                Player = player;
                User = currentPlayer;
            }

            private Player User { get; set; }
            public Player Player { get; set; }
            public Nationality Nationality { get; set; }
            public string DisplayName { get { return Player.GetDisplayName(Player, User); } }

            public PlayerRadioButtonModel PlayerRadioButtons
            {
                get
                {
                    return new PlayerRadioButtonModel(Nationality)
                               {
                                   IsCpu = IsCpu,
                                   IsOpen = IsOpen,
                                   IsSelf = IsSelf,
                               };
                }
            }

            public bool IsSelf { get { return User.Equals(Player); } }
            public bool IsCpu { get { return !IsOpen && Player.IsCpu; } }
            public bool IsOpen { get { return Player == null; } }

            public bool CanEdit
            {
                get { return IsCpu || IsOpen || IsSelf; }
            }
        }

        public bool CanEdit(Player player)
        {
            return new PlayerState(player, CurrentPlayer).CanEdit;
        }
    }
}
