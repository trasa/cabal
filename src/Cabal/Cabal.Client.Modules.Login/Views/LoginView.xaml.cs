using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Cabal.Client.Core.Controls;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.Login.PresentationModels;
using Cabal.Core.Shared.Model;
using Microsoft.Windows.Controls;

namespace Cabal.Client.Modules.Login.Views
{
    public interface ILoginView : IView<ILoginPresentationModel>
    {
        
    }

    public partial class LoginView : ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public ILoginPresentationModel Model
        {
            get { return (ILoginPresentationModel)DataContext; }
            set { DataContext = value; }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Model.Password = txtPassword.Password;
        }
        
        private void OnActiveGameClick(object sender, RoutedEventArgs e)
        {
            var cell = (DataGridCell)((FrameworkElement)sender).Parent;
            int gameId = cell.GetRowDataItem<GameDto>().Id;
            GlobalCommands.SelectActiveGameCommand.Execute(gameId);
        }
    }
}
