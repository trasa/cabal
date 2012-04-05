using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Cabal.Client.Core.Api;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Model;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Modules.Login.Views;
using Cabal.Core.Shared.Model;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace Cabal.Client.Modules.Login.PresentationModels
{
    public interface ILoginPresentationModel : IPresentationModel<ILoginView>
    {
        string UserName { get; set; }
        string Password { get; set; }
        string ValidationMessage { get; set; }
    }

    public class LoginPresentationModel : ViewModelBase<ILoginView>, ILoginPresentationModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly SessionState sessionState;
        private readonly IGlobalRegions globalRegions;
        private readonly IAccountService accountService;
        private string username;
        private string password;
        private string validationMessage;
        private Visibility gamesGridVisibility = Visibility.Hidden;
        private ObservableCollection<GameDto> activeGames;

        private readonly DelegateCommand<object> loginCommand;
        private readonly DelegateCommand<int> selectActiveGameCommand;

        public LoginPresentationModel()
        {
        }

        public LoginPresentationModel(ILoginView view, 
            IGlobalCommandsProxy commandsProxy, 
            IEventAggregator eventAggregator,
            SessionState sessionState,
            IGlobalRegions globalRegions,
            IAccountService accountService)
        {
            this.eventAggregator = eventAggregator;
            this.sessionState = sessionState;
            this.globalRegions = globalRegions;
            this.accountService = accountService;
            View = view;
            View.Model = this;

            loginCommand = new DelegateCommand<object>(Login, CanLogin);
            commandsProxy.LoginCommand.RegisterCommand(loginCommand);

            selectActiveGameCommand = new DelegateCommand<int>(SelectActiveGame, CanSelectActiveGame);
            commandsProxy.SelectActiveGameCommand.RegisterCommand(selectActiveGameCommand);
        }



        public string UserName
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    InvokePropertyChanged("UserName");
                    loginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    InvokePropertyChanged("Password");
                    loginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string ValidationMessage
        {
            get { return validationMessage; }
            set
            {
                if (validationMessage != value)
                {
                    validationMessage = value;
                    InvokePropertyChanged("ValidationMessage");
                }
            }
        }

        public Visibility GamesGridVisibility
        {
            get { return gamesGridVisibility;}
            set
            {
                if (gamesGridVisibility != value)
                {
                    gamesGridVisibility = value;
                    InvokePropertyChanged("GamesGridVisibility");
                }
            }
        }

        public ObservableCollection<GameDto> ActiveGames
        {
            get{ return activeGames;}
            set
            {
                if (activeGames != value)
                {
                    activeGames = value;
                    InvokePropertyChanged("ActiveGames");
                }
            }

        }

        public void Login(object o)
        {
            string authToken = accountService.Login(UserName, Password);
            if (!string.IsNullOrEmpty(authToken))
            {
                LoginSuccess(authToken);
            }
            else
            {
                LoginFailed();
            }
        }

        private void LoginSuccess(string authToken)
        {
            sessionState.UserName = UserName;
            sessionState.AuthToken = authToken;
            ValidationMessage = string.Empty;
            GamesGridVisibility = Visibility.Visible;
            ActiveGames = new ObservableCollection<GameDto>(accountService.GetActiveGames(UserName));
        }

        private void LoginFailed()
        {
            sessionState.AuthToken = null;
            sessionState.UserName = null;
            ValidationMessage = "Login Failed.";
            GamesGridVisibility = Visibility.Collapsed;
            ActiveGames = new ObservableCollection<GameDto>();
        }

        public bool CanLogin(object o)
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password));
        }

        public void SelectActiveGame(int gameId)
        {
            if (CanSelectActiveGame(gameId))
            {
                sessionState.Game = ActiveGames.Single(g => g.Id == gameId);
                eventAggregator.GetEvent<GameSelectedEvent>().Publish(gameId);
                globalRegions.MainRegion.Deactivate(View);
            } 
            else
            {
                // fail
                sessionState.Game = null;
            }
        }

        public bool CanSelectActiveGame(int gameId)
        {
            return sessionState.AuthToken != null;
        }
    }
}
