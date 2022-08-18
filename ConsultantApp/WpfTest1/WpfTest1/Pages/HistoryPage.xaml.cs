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

namespace WpfTest1.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
            comboFilter.Items.Add("Логин");
            comboFilter.Items.Add("Дата");
            comboFilter.Items.Add("Результат");
            comboFilter.SelectedIndex = 0;
            Update();
        }

        private void Update()
        {
            List<LoginHistory> currentUser = СonsultantEntities.GetContext().LoginHistory.ToList();
            

            if (comboFilter.SelectedIndex == 0)
            {
                dGridHistory.ItemsSource = currentUser.OrderByDescending(p => p.Date);
                //dGridHistory.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Date", System.ComponentModel.ListSortDirection.Descending));
            }
            if (comboFilter.SelectedIndex == 1)
                dGridHistory.ItemsSource = currentUser.OrderBy(p => p.Login);
            if (comboFilter.SelectedIndex == 2)
                dGridHistory.ItemsSource = currentUser.OrderBy(p => p.Successful);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //СonsultantEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dGridHistory.ItemsSource = СonsultantEntities.GetContext().LoginHistory.ToList();
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
