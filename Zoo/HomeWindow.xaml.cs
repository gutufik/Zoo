using System;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public static ObservableCollection<ClimatZone> climatZones { get; set; }
        public HomeWindow()
        {
            InitializeComponent();
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            this.DataContext = this;
        }
    }
}
