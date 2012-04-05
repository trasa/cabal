using System;
using System.Windows;
using Microsoft.Practices.Composite.Presentation.Commands;
using VisibleTest.Client.Core.Infrastructure;
using VisibleTest.Client.Core.PresentationModels;
using VisibleTest.Client.Modules.Board.Views;

namespace VisibleTest.Client.Modules.Board.PresentationModels
{
    public interface IBoardPresentationModel : IPresentationModel<IBoardView>
    {
        Visibility ShowPiece { get; set;}
        string SomeText { get; set; }
    }

    public class BoardPresentationModel : ViewModelBase<IBoardView>, IBoardPresentationModel
    {

        private readonly DelegateCommand<object> refreshMapCommand;

        public BoardPresentationModel(IBoardView view, GlobalCommandsProxy commandsProxy)
        {
            View = view;
            View.Model = this;

            refreshMapCommand = new DelegateCommand<object>(RefreshMap, o => true);
            commandsProxy.RefreshMapCommand.RegisterCommand(refreshMapCommand);
        }

        private void RefreshMap(object parameter)
        {
//            ShowPiece = ShowPiece == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            View.SetVisible();
        }

        private Visibility pieceVisible = Visibility.Hidden;
        public Visibility ShowPiece
        {
            get { return pieceVisible; }
            set
            {
                pieceVisible = value;
                InvokePropertyChanged("ShowPiece");
            }
        }

        private string someText = "blah";

        public BoardPresentationModel()
        {
        }

        public string SomeText
        {
            get { return someText;}
            set { someText = value; InvokePropertyChanged("SomeText"); }
        }
    }
}
