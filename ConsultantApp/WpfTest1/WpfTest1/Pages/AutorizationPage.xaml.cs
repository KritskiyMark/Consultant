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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTest1.Entities;
using WpfTest1.Class;

namespace WpfTest1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        private string _userName = "";
        public AutorizationPage()
        {
            InitializeComponent();
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/openeye.png", UriKind.Relative));
        }

        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }
        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Password.Password.Length > 0)
                ImgShowHide.Visibility = Visibility.Visible;
            else
                ImgShowHide.Visibility = Visibility.Hidden;
        }

        void ShowPassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/openeye.png", UriKind.Relative));
            PassBoxSec.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Hidden;
            PassBoxSec.Text = Password.Password;
        }
        void HidePassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("/Resources/closeeye.png", UriKind.Relative));
            PassBoxSec.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
            Password.Focus();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool exitForeach = false;

            foreach (var user in СonsultantEntities.GetContext().Users.ToArray())
            {
                if (Login.Text == user.Login)
                {
                    _userName = user.Login;
                }
                if (Login.Text == user.Login && Password.Password == user.Password)
                {
                    if (user.TypeCode == 1)
                    {
                        addEntryHistory(Login.Text, true);
                        Manager.MainFrame.Navigate(new AdminPage());
                    }
                    else if (user.TypeCode == 2)
                    {
                        addEntryHistory(Login.Text, true);
                        Manager.MainFrame.Navigate(new ManagerPage());
                    }
                    exitForeach = false;
                    break;

                }
                else
                {
                    exitForeach = true;
                }
            }
            if (exitForeach == true)
            {
                if (_userName != "")
                {
                    addEntryHistory(_userName, false);
                }
                MessageBox.Show("Неверный логин или пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addEntryHistory(string login, bool access)
        {
            try
            {
                LoginHistory historyEnter = new LoginHistory();
                historyEnter.Login = login;
                historyEnter.Date = DateTime.Now;
                historyEnter.Successful = access;
                СonsultantEntities.GetContext().LoginHistory.Add(historyEnter);
                СonsultantEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }


        }

        private void PassBoxSec_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
