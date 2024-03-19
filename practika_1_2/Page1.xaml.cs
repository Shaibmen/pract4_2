using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private ChurchEntities4 basadan = new ChurchEntities4();
        public List<String> IerarchDolz = new List<String>();
        public Page1()
        {
            InitializeComponent();
            FirstGrid.ItemsSource = basadan.Priest.ToList();
            Filter.ItemsSource = basadan.Priest.ToList();


            IerarchDolz.Add("Священник");
            IerarchDolz.Add("Священница");
            IerarchDolz.Add("Папа");
            IerarchDolz.Add("Кардинал");
            ierach.ItemsSource = IerarchDolz;
            ierach.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Priest priest = new Priest();
            priest.first_name = name.Text;
            priest.last_name = secondName.Text;
            priest.middle_name = middleName.Text;
            priest.ierarch_position = ierach.Text;

            basadan.Priest.Add(priest);

            basadan.SaveChanges();
            FirstGrid.ItemsSource = basadan.Priest.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (FirstGrid.SelectedItem != null)
            {
                var selected = FirstGrid.SelectedItem as Priest;

                selected.first_name = name.Text;
                selected.last_name = secondName.Text;
                selected.middle_name = middleName.Text;
                selected.ierarch_position = ierach.Text;
            }

            basadan.SaveChanges();
            FirstGrid.ItemsSource = basadan.Priest.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                basadan.Priest.Remove(FirstGrid.SelectedItem as Priest);
                basadan.SaveChanges();
                FirstGrid.ItemsSource = basadan.Priest.ToList();
            }
            catch
            {
                MessageBox.Show("анлак");
            }
            
        }

        private void ierach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FirstGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = FirstGrid.SelectedItem as Priest;
                name.Text = selected.first_name;
                secondName.Text = selected.last_name;
                middleName.Text = selected.middle_name;
            }
            catch
            {
                MessageBox.Show("На пустое не тыкать");
            }

        }

        private void PoiskButton_Click(object sender, RoutedEventArgs e)
        {
            FirstGrid.ItemsSource = basadan.Priest.ToList().Where(item => (item as Priest).first_name.ToString().Contains(Poisk.Text));
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedItem != null)
            {
                var selected = Filter.SelectedItem as Priest;
                FirstGrid.ItemsSource = basadan.Priest.ToList().Where(item => item as Priest == selected);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FirstGrid.ItemsSource = basadan.Priest.ToList();
        }
    }
}
