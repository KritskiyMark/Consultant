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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        private Users _currentUsers = new Users();
        public AddUsers(Users selectedUsers)
        {
            InitializeComponent();
            if (selectedUsers != null)
                _currentUsers = selectedUsers;
            DataContext = _currentUsers;
            ComboType.ItemsSource = СonsultantEntities.GetContext().Type.ToList();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUsers.Name))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentUsers.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentUsers.Password))
                errors.AppendLine("Укажите пароль");
            if (_currentUsers.Password == null)
                errors.AppendLine("Выбирете тип");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            СonsultantEntities.GetContext().Users.Add(_currentUsers);

            try
            {
                СonsultantEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
