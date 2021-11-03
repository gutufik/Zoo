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
    /// Логика взаимодействия для PageWorkZones.xaml
    /// </summary>
    public partial class PageWorkZones : Page
    {
        public ObservableCollection<Clerk_Zone> clerk_Zones { get; set; }
        public ObservableCollection<User> users { get; set; }
        public ObservableCollection<ClimatZone> climatZones { get; set; }

        public IEnumerable<WorkZone> workZones { get; set; }
        public User user1;

        public PageWorkZones(User user)
        {
            user1 = user;
            InitializeComponent();
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            clerk_Zones = new ObservableCollection<Clerk_Zone>(DBConnect.connection.Clerk_Zone.ToList());
            this.DataContext = this;

            if (user.CategoryID == 1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }

            workZones = from cz in clerk_Zones
                        join clz in climatZones
                        on cz.ZoneID equals clz.ZoneID
                        join u in users
                        on cz.ClerkID equals u.UserID
                        select new WorkZone
                        {
                            ClerkID = u.UserID,
                            ZoneID = clz.ZoneID,
                            ClerkName = u.UserName,
                            ZoneName = clz.ZoneName
                        };

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PageAddWorkZone(user1));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var wz = dg_WorkZones.SelectedItem as WorkZone;
                var clerk_ = from cz_ in clerk_Zones
                              where cz_.ClerkID == wz.ClerkID
                              where cz_.ZoneID == wz.ZoneID
                              select new Clerk_Zone
                              {
                                  CZ_ID = cz_.CZ_ID,
                                  ClerkID = wz.ClerkID,
                                  ZoneID = wz.ZoneID
                              };

                foreach (var c in clerk_)
                {
                    DBConnect.connection.Clerk_Zone.Remove(DBConnect.connection.Clerk_Zone.Find(c.CZ_ID));
                    DBConnect.connection.SaveChanges();
                    NavigationService.Navigate(new PageWorkZones(user1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }
    }
    public class WorkZone
    { 
        public int ClerkID { get; set; }
        public string ClerkName { get; set; }
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
    }
}
