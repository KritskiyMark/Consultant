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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            comboFilter.Items.Add("Имя");
            comboFilter.Items.Add("Логин");
            comboFilter.Items.Add("Пароль");
            comboFilter.Items.Add("Тип");
            comboFilter.SelectedIndex = 0;
            Update();
            //DGridUsers.ItemsSource = СonsultantEntities.GetContext().Users.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUsers(null));
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUsers((sender as Button).DataContext as Users));
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUsers(null));
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Users>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    СonsultantEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    СonsultantEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridUsers.ItemsSource = СonsultantEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //СonsultantEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridUsers.ItemsSource = СonsultantEntities.GetContext().Users.ToList();
            }
        }

        private void Update()
        {
            List<Users> currentUser = СonsultantEntities.GetContext().Users.ToList();
            currentUser = currentUser.Where(p => p.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();

            if (comboFilter.SelectedIndex == 0)
                DGridUsers.ItemsSource = currentUser.OrderBy(p => p.ID).ToList();
            if (comboFilter.SelectedIndex == 1)
                DGridUsers.ItemsSource = currentUser.OrderBy(p => p.Login);
            if (comboFilter.SelectedIndex == 2)
                DGridUsers.ItemsSource = currentUser.OrderBy(p => p.Name);
            if (comboFilter.SelectedIndex == 3)
                DGridUsers.ItemsSource = currentUser.OrderBy(p => p.Password);
            if (comboFilter.SelectedIndex == 4)
                DGridUsers.ItemsSource = currentUser.OrderBy(p => p.TypeCode);


        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void DGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
