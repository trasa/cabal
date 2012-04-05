using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.Board.PresentationModels;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Modules.Board.Views
{
    public interface IBoardView
    {
        IBoardPresentationModel Model { get; set; }
        void SetTerritoryView(TerritoryStateDto dto);
        void ResetMap();

        event EventHandler<TerritorySelectedEventArgs> TerritorySelected;

    }

    public partial class BoardView : IBoardView
    {
        private Territory selectedTerritory;

        public BoardView()
        {
            InitializeComponent();
            SetTerritoryControls();
        }

        public IBoardPresentationModel Model
        {
            get { return (IBoardPresentationModel)DataContext;}
            set { DataContext = value; }
        }


        private Piece GetPiece(string territoryName)
        {
            if (!territoryName.StartsWith("Piece"))
                territoryName = "Piece" + territoryName;

            return (Piece)GetTerritoryPart(territoryName);
        }

        private Path GetPath(string territoryName)
        {
            return (Path)GetTerritoryPart(territoryName);
        }

        private object GetTerritoryPart(string territoryName)
        {
            return (GetType().GetField(territoryName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this));
        }


        public void SetTerritoryView(TerritoryStateDto dto)
        {
            Territory territory = Territory.GetById(dto.TerritoryId);
            string territoryControlName = territory.ControlName;
            
            GetPiece(territoryControlName)
                .SetMarkerImage(dto.ArmyNationalities);
  
            // land territories: set color of path.
            if (territory is LandTerritory)
            {
                GetPath(territoryControlName)
                    .SetValue(Shape.FillProperty,
                              NationalityColor.GetColor(dto.ControlledBy));
            }
        }

        public void ResetMap()
        {
            zoomViewer.Reset();
        }


        private void SetTerritoryControls()
        {
            var territoryPaths = from f in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                 where f.FieldType == typeof(Path) || f.FieldType == typeof(Piece)
                                 select new
                                 {
                                     TerritoryName = f.Name,
                                     Element = (FrameworkElement)f.GetValue(this)
                                 };

            foreach (var pathInfo in territoryPaths)
            {
                string friendlyTerritoryName = pathInfo.TerritoryName.Replace("Piece", "").Replace('_', ' ');
                Territory territory = Territory.GetByName(friendlyTerritoryName);
                if (territory == null)
                {
                    throw new Exception("Could not find a Territory for element " + pathInfo.TerritoryName);
                }
                
                ToolTipService.SetToolTip(pathInfo.Element,friendlyTerritoryName);
                
                // Properties For All:
                pathInfo.Element.MouseLeftButtonDown += Territory_MouseLeftButtonDown;

                
                if (pathInfo.Element is Piece)
                {
                    // Piece specific things:
                    pathInfo.Element.Visibility = Visibility.Hidden;
                } 
                else if (pathInfo.Element is Path)
                {
                    // Path specific things
                    pathInfo.Element.Opacity = NationalityColor.Opacity;
                    
                }
            }
        }

        private void Territory_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string controlName = ((FrameworkElement)sender).Name;
            Territory t = Territory.GetByControlName(controlName);
            
            if (t == null)
                throw new Exception("Can't find territory for component " + controlName);

            OnTerritorySelected(new TerritorySelectedEventArgs(t));
        }

        
        public event EventHandler<TerritorySelectedEventArgs> TerritorySelected;

        protected virtual void OnTerritorySelected(TerritorySelectedEventArgs e)
        {
            UnselectCurrentTerritory();
            SelectTerritory(e.Territory);

            // for thread safety:
            EventHandler<TerritorySelectedEventArgs> handle = TerritorySelected;
            if (handle != null)
                handle(this, e);
        }

        private void UnselectCurrentTerritory()
        {
            if (selectedTerritory == null) return;

            Path p = GetPath(selectedTerritory.ControlName);
            p.Opacity = NationalityColor.Opacity;
            if (selectedTerritory is SeaTerritory)
            {
                p.SetValue(Shape.FillProperty, NationalityColor.None);
            }
        }

        private void SelectTerritory(Territory t)
        {
            selectedTerritory = t;
            Path p = GetPath(t.ControlName);
            if (selectedTerritory is SeaTerritory)
            {
                p.SetValue(Shape.FillProperty, NationalityColor.Sea);
            }
            // TODO how to highlight neutral countries that are not controlled by anybody yet?
            // will wait until we have a better idea of what this will look like with occupied neutrals, 
            // before deciding on how to approach this.
            p.Opacity = NationalityColor.HighlightOpacity;
        }
    }

    public class TerritorySelectedEventArgs : EventArgs
    {
        public TerritorySelectedEventArgs(Territory t)
        {
            Territory = t;
        }

        public Territory Territory { get; set; }
    }
}

