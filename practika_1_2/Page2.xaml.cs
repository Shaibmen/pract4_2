using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace practika_1_2
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private ChurchEntities4 basadan = new ChurchEntities4();
        public Page2()
        {
            InitializeComponent();
            SecondGrid.ItemsSource = basadan.ChurchService.ToList();
            Filter.ItemsSource = basadan.ChurchService.ToList();

            idClerc.ItemsSource = basadan.Priest.ToList();
            idClerc.DisplayMemberPath = "first_name";
            idClerc.SelectedIndex = 0;

            idChurc.ItemsSource = basadan.Church.ToList();
            idChurc.DisplayMemberPath = "name";
            idChurc.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {

            ChurchService churchService = new ChurchService();


            int selectedChurc = (idChurc.SelectedItem as Church).churchID;
            int selectedClerc = (idClerc.SelectedItem as Priest).PriestID;


            churchService.service_date = Convert.ToDateTime(data.Text);
            churchService.priest_id = Convert.ToInt32(selectedClerc);
            churchService.church_id = Convert.ToInt32(selectedChurc);

            churchService.Church = idChurc.SelectedItem as Church;
            churchService.Priest = idClerc.SelectedItem as Priest;
            basadan.ChurchService.Add(churchService);

            basadan.SaveChanges();
            SecondGrid.ItemsSource = basadan.ChurchService.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        { 

            if (SecondGrid.SelectedItem != null)
            {

                var selected = SecondGrid.SelectedItem as ChurchService;

                int selectedChurc = (idChurc.SelectedItem as Church).churchID;
                int selectedClerc = (idClerc.SelectedItem as Priest).PriestID;


                selected.service_date = Convert.ToDateTime(data.Text);
                selected.priest_id = Convert.ToInt32(selectedClerc);
                selected.church_id = Convert.ToInt32(selectedChurc);

                selected.Church = idChurc.SelectedItem as Church;
                selected.Priest = idClerc.SelectedItem as Priest;
            }
            

            basadan.SaveChanges();
            SecondGrid.ItemsSource = basadan.ChurchService.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                basadan.ChurchService.Remove(SecondGrid.SelectedItem as ChurchService);
                basadan.SaveChanges();
                SecondGrid.ItemsSource = basadan.ChurchService.ToList();
            }
            catch
            {
                MessageBox.Show("анлак");
            }
        }

        private void ierach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SecondGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = SecondGrid.SelectedItem as ChurchService;
                data.Text = Convert.ToString(selected.service_date);
            } 
            catch
            {
                MessageBox.Show("На пустое не тыкать");
            }
            
        }

        private void PoiskButton_Click(object sender, RoutedEventArgs e)
        {
            SecondGrid.ItemsSource = basadan.ChurchService.ToList().Where(item => (item as ChurchService).priest_id.ToString().Contains(Poisk.Text));
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedItem != null)
            {
                var selected = Filter.SelectedItem as ChurchService;
                SecondGrid.ItemsSource = basadan.ChurchService.ToList().Where(item => item as ChurchService == selected);
            }
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            SecondGrid.ItemsSource = basadan.ChurchService.ToList();
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
