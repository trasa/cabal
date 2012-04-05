using System.Windows;
using System.Windows.Input;

namespace ZoomPan
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
            double zoom = e.Delta > 0 ? .2 : -0.2; // TODO
            ScaleMap(zoom, mousePoint.X, mousePoint.Y);
        }


        private void ScaleMap(double changeBy, double centerX, double centerY)
        {

            boardScale += changeBy;
            if (boardScale < 1)
                boardScale = 1;
            else if (boardScale > 4)
                boardScale = 4;

//            if (zoomIn)
//            {
//                scale.CenterX = centerX;
//                scale.CenterY = centerY;
//                double realCenterX = (centerX - translate.X) / scale.ScaleX;
//                double realCenterY = (centerY - translate.Y) / scale.ScaleY;
//                translate.X = centerX - realCenterX * scale.ScaleX;
//                translate.Y = centerY - realCenterY * scale.ScaleY;
//            }


//            aniScaleX.To = boardScale;
//            aniScaleY.To = boardScale;
            scale.ScaleX = boardScale;
            scale.ScaleY = boardScale;


//            sbScale.Begin();
//            sbScale.Completed += (s, e) =>
//            {
//                ZoomEnable.Width = LayoutRoot.Width * boardScale;
//                ZoomEnable.Height = LayoutRoot.Height * boardScale;

//            };
        }
    }
}
