using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using System.Collections.ObjectModel;
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
using System.Data.Sql;

namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для PageArctic.xaml
    /// </summary>
    
    public partial class PageSelectedZone : Page
    {
        public static ObservableCollection<Animal> animals { get; set; }
        public static ObservableCollection<ClimatZone> zones { get; set; }
        public static ObservableCollection<Zone_Animal> zone_Animals { get; set; }
        public static IEnumerable<SelectedAnimal> selectedAnimals { get; set; }

        public PageSelectedZone(ClimatZone zone)
        {
            
            InitializeComponent();
            
            animals = new ObservableCollection<Animal>(DBConnect.connection.Animal.ToList());
            zones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            zone_Animals = new ObservableCollection<Zone_Animal>(DBConnect.connection.Zone_Animal.ToList());

            selectedAnimals = from a in animals
                              join z in zone_Animals
                              on a.AnimalID equals z.AnimalID
                              where zone.ZoneID == z.ZoneID
                              select new SelectedAnimal
                              {
                                  AnimalName = a.AnimalName,
                                  ZoneID = z.ZoneID,
                                  AnimalID = a.AnimalID,
                                  ZoneName = zone.ZoneName,
                                  AnimalImage = a.AnimalImage
                              };

            tb_ZoneName.Text = zone.ZoneName;
            this.DataContext = this;
            
        }

        private void lv_Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = DBConnect.connection.Animal.Find((lv_Animals.SelectedItem as SelectedAnimal).AnimalID);

            //if (true)
            //    NavigationService.Navigate(new PageLookAnimal(a));

            NavigationService.Navigate(new PageAnimalDiet(a));
        }
    }

    public class SelectedAnimal
    { 
        public int ZoneID { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string ZoneName { get; set; }
        public string AnimalImage { get; set; }
    }
}
