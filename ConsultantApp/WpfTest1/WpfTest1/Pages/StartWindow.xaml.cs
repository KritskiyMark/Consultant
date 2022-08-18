using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTest1.Class;

namespace WpfTest1.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AutorizationPage());
            Manager.MainFrame = MainFrame;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.Content.GetType().Name == "AdminPage")
            {
                btnHistory.Visibility = Visibility.Visible;
            }
            else if (MainFrame.Content.GetType().Name == "AutorizationPage")
            {
                btnHistory.Visibility = Visibility.Collapsed;
            }
            if (MainFrame.Content.GetType().Name == "ManagerPage")
            {
                btnPrint.Visibility = Visibility.Visible;
            }
            else if (MainFrame.Content.GetType().Name == "AutorizationPage")
            {
                btnPrint.Visibility = Visibility.Collapsed;
            }
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Collapsed;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HistoryPage());
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PrintPage());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
