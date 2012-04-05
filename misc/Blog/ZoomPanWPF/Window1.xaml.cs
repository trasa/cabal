using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZoomPanWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private double boardScale = 1.0;
        private readonly Storyboard sbScale;
        private readonly DoubleAnimation aniScaleX;
        private readonly DoubleAnimation aniScaleY;

        public Window1()
        {
            InitializeComponent();
            sbScale = (Storyboard)Resources["sbScale"];
            aniScaleX = (DoubleAnimation)sbScale.Children[0];
            aniScaleY = (DoubleAnimation)sbScale.Children[1];
        }

        private void LayoutRoot_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePoint = e.GetPosition(LayoutRoot);
            double zoom = e.Delta > 0 ? 0.2 : -0.2;
            ScaleMap(zoom, mousePoint.X, mousePoint.Y);
        }


        private void ScaleMap(double changeBy, double centerX, double centerY)
        {
            boardScale += changeBy;
            if (boardScale < 1)
                boardScale = 1;
            else if (boardScale > 4)
                boardScale = 4;
            
            bool zoomIn = changeBy > 0;


            // NOTE: in WPF, these values ARE effective - but changing CenterXY
            // when zooming out gives an undesirable visual effect - so we
            // only update when zooming in.
            if (zoomIn)
            {
                scale.CenterX = centerX;
                scale.CenterY = centerY;
            }

            aniScaleX.To = boardScale;
            aniScaleY.To = boardScale;

            sbScale.Begin();
        }
    }
}
