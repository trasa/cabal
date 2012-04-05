using System.Windows.Input;

namespace ZoomWpfTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 
    {
        

        public Window1()
        {
            InitializeComponent();

        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) zoomViewer.Reset();
        }
    }
}
