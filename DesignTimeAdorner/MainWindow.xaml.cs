using System;
using System.Windows;

namespace DesignTimeAdorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += this.MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Group_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Group_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
