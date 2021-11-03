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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для PageZoneSelect.xaml
    /// </summary>
    public partial class PageZoneSelect : Page
    {
        public static ObservableCollection<ClimatZone> climatZones { get; set; }
        public User user { get; set; }
        public PageZoneSelect(User user)
        {
            InitializeComponent();
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            this.DataContext = this;
            this.user = user;

            switch (user.CategoryID)
            {
                case 1:
                    btnWorkZones.Visibility = Visibility.Visible;
                    btnUsers.Visibility = Visibility.Visible;
                    break;
                case 2:
                    btnWorkZones.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void lvZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new PageSelectedZone((ClimatZone)lv_Zone.SelectedItem, user));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUsers());
        }

        private void btnWorkZones_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageWorkZones(user));
        }
    }
}
