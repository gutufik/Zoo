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
    
    public partial class PageArctic : Page
    {
        public static ObservableCollection<Animal> animals { get; set; }
        public static ObservableCollection<ClimatZone> zones { get; set; }
        public static IEnumerable<Animal_Zone> result { get; set; }

        public PageArctic()
        {
            //сделать 
            
            InitializeComponent();
            animals = new ObservableCollection<Animal>(DBConnect.connection.Animal.ToList());
            zones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            result = from animal in animals
                     join zone in zones
                     on animal.ClimatZone as ClimatZone equals zone as ClimatZone
                     select new Animal_Zone
                     {
                         animal = animal.AnimalName,
                         zone = zone.ZoneName
                     };


            this.DataContext = this;
            
        }
    }

    public class Animal_Zone
    {
        public string animal { get; set; }
        public string zone { get; set; }
    }
}
