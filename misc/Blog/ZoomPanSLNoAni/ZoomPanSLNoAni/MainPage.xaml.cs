using System.Windows;
using System.Windows.Input;

namespace ZoomPanSLNoAni
{
    public partial class MainPage
    {
        private double boardScale = 1.0;

        public MainPage()
        {
            InitializeComponent();
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
            // No animation, then CenterXY works fine. 
            if (zoomIn)
            {
                scale.CenterX = centerX;
                scale.CenterY = centerY;
            }
            scale.ScaleX = boardScale;
            scale.ScaleY = boardScale;
        }
    }
}
