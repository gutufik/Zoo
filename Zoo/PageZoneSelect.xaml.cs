﻿using System;
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
        public PageZoneSelect(User user)
        {
            InitializeComponent();
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            this.DataContext = this;
            if (user.CategoryID != 3)
                btnUsers.Visibility = Visibility.Visible;
        }
        public PageZoneSelect()
        {
            InitializeComponent();
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            this.DataContext = this;
            btnWorkZones.Visibility = Visibility.Visible;
            btnUsers.Visibility = Visibility.Visible;
        }
        private void lvZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show($"{((ClimatZone)lv_Zone.SelectedItem).ZoneName}");
            NavigationService.Navigate(new PageSelectedZone((ClimatZone)lv_Zone.SelectedItem));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUsers());
        }

        private void btnWorkZones_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageWorkZones());
        }
    }
}
