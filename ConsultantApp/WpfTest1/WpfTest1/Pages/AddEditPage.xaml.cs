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
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;

namespace WpfTest1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAditPage.xaml
    /// </summary>
    public partial class AddAditPage : Page
    {
        private Product _currentProduct = new Product();
        public AddAditPage(Product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                _currentProduct = selectedProduct;
            ComboManufacturer.ItemsSource = СonsultantEntities.GetContext().Manufacturer.ToList();
            DataContext = _currentProduct;
            
           /* DataContext = new Content();*/
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProduct.Name))
                errors.AppendLine("Укажите название товара");
            if (string.IsNullOrWhiteSpace(_currentProduct.Model))
                errors.AppendLine("Укажите название модели");
            if (string.IsNullOrWhiteSpace(_currentProduct.Description))
                errors.AppendLine("Укажите название товара");
            if (_currentProduct.Manufacturer == null)
                errors.AppendLine("Выбирете производителя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProduct.ID == 0)
            {
                _currentProduct.ReceiptDate = DateTime.Now;
                СonsultantEntities.GetContext().Product.Add(_currentProduct);
            }

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

       /* // Создадим класс для реализации интерфейса ICommand
        // Чтобы использовать его в XAML'е
        public class Command : ICommand
        {
            public Command(Action action)
            {
                this.action = action;
            }

            Action action;

            EventHandler canExecuteChanged;
            event EventHandler ICommand.CanExecuteChanged
            {
                add { canExecuteChanged += value; }
                remove { canExecuteChanged -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                action();
            }
        }*/

        /*// В классе Content реализуем интерфейс INotifyPropertyChanged
        // Чтобы послать нотификацию о том, что свойство Image поменялось
        public class Content : INotifyPropertyChanged
        {
            public Content()
            {
                // Инициализация команды
                openFileDialogCommand = new Command(ExecuteOpenFileDialog);
                // Инициализация OpenFileDialog
                openFileDialog = new OpenFileDialog()
                {
                    Multiselect = true,
                    Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf"
                };
            }

            readonly OpenFileDialog openFileDialog;

            // Наша картинка
            public ImageSource Image { get; private set; }

            readonly ICommand openFileDialogCommand;
            public ICommand OpenFileDialogCommand { get { return openFileDialogCommand; } }

            // Действие при нажатии на кнопку "Open File Dialog"
            void ExecuteOpenFileDialog()
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        Image = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        RaisePropertyChanged("Image");
                    }
                }
            }

            // Реализация интерфейса INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ComboManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }*/
    }
}
