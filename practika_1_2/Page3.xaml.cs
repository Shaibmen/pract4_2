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

namespace practika_1_2
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private ChurchEntities4 basadan = new ChurchEntities4();
        public Page3()
        {
            InitializeComponent();
            ThirdGrid.ItemsSource = basadan.Church.ToList();
            Filter.ItemsSource = basadan.Church.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Church church = new Church();
            church.name = name.Text;
            church.address = address.Text;
            church.established_date = Convert.ToDateTime(data.Text);

            basadan.Church.Add(church);

            basadan.SaveChanges();
            ThirdGrid.ItemsSource = basadan.Church.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ThirdGrid.SelectedItem != null)
            {
                var selected = ThirdGrid.SelectedItem as Church;

                selected.name = name.Text;
                selected.address = address.Text;
                selected.established_date = Convert.ToDateTime(data.Text);

            }

            basadan.SaveChanges();
            ThirdGrid.ItemsSource = basadan.Church.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                basadan.Church.Remove(ThirdGrid.SelectedItem as Church);
                basadan.SaveChanges();
                ThirdGrid.ItemsSource = basadan.Church.ToList();
            }
            catch
            {
                MessageBox.Show("анлак");
            }
        }

        private void ierach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ThirdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = ThirdGrid.SelectedItem as Church;

                name.Text = selected.name;
                address.Text = selected.address;
                data.Text = selected.established_date.ToString();
            } catch
            {
                MessageBox.Show("На пустое не тыкать");
            }
            
        }

        private void PoiskButton_Click(object sender, RoutedEventArgs e)
        {
            ThirdGrid.ItemsSource = basadan.Church.ToList().Where(item => item.name.Contains(Poisk.Text));
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedItem != null)
            {
                var selected = Filter.SelectedItem as Church;
                ThirdGrid.ItemsSource = basadan.Church.ToList().Where(item => item as Church == selected);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            ThirdGrid.ItemsSource = basadan.Church.ToList();
        }
    }
}
