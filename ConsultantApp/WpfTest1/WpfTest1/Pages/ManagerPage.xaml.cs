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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            comboFilter.Items.Add("Все");
            comboFilter.Items.Add("Название");
            comboFilter.Items.Add("Модель");
            comboFilter.Items.Add("Цена");
            comboFilter.SelectedIndex = 0;
            Update();
            //DGridProduct.ItemsSource = СonsultantEntities.GetContext().Product.ToList();
            var currentProduct = СonsultantEntities.GetContext().Product.ToList();
            LViewProduct.ItemsSource = currentProduct;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAditPage(null));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = LViewProduct.SelectedItem as Product;

            Manager.MainFrame.Navigate(new AddAditPage(a));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAditPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = LViewProduct.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    СonsultantEntities.GetContext().Product.RemoveRange(productForRemoving);
                    СonsultantEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LViewProduct.ItemsSource = СonsultantEntities.GetContext().Product.ToList();
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
                СonsultantEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewProduct.ItemsSource = СonsultantEntities.GetContext().Product.ToList();
                Update();
            }
        }

        private void Update()
        {
            List<Product> currentProduct = СonsultantEntities.GetContext().Product.ToList();
            currentProduct = currentProduct.Where(p => p.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();

            if (comboFilter.SelectedIndex == 0)
                LViewProduct.ItemsSource = currentProduct.OrderBy(p => p.ID).ToList();
            if (comboFilter.SelectedIndex == 1)
                LViewProduct.ItemsSource = currentProduct.OrderBy(p => p.Name);
            if (comboFilter.SelectedIndex == 2)
                LViewProduct.ItemsSource = currentProduct.OrderBy(p => p.Model);
            if (comboFilter.SelectedIndex == 3)
                LViewProduct.ItemsSource = currentProduct.OrderByDescending(p => p.Cost);
            if (comboFilter.SelectedIndex == 4)
                LViewProduct.ItemsSource = currentProduct.OrderBy(p => p.Manufacturer);


        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

    }
}
