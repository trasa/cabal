using System.Windows;
using System.Windows.Input;

namespace ZoomPanSL
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

            // NOTE: In Silverlight 3, these values are effective
            // only for the first animation/zoom.  Even though
            // we'll be updating the variables on other Zoom operations,
            // the image won't "zoom in" to any other part of the image.
            scale.CenterX = centerX;
            scale.CenterY = centerY;

            aniScaleX.To = boardScale;
            aniScaleY.To = boardScale;

            sbScale.Begin();
        }
    }
}
