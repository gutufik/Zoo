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

namespace Zoo.Pages
{
    /// <summary>
    /// Interaction logic for PageAddWorkZone.xaml
    /// </summary>
    public partial class PageAddWorkZone : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public static ObservableCollection<ClimatZone> climatZones{ get; set; }
        public PageAddWorkZone()
        {
            InitializeComponent();
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            this.DataContext = this;
            users = new ObservableCollection<User>(from u in users
                                                where u.CategoryID == 2
                                                select new User
                                                {
                                                    UserID = u.UserID,
                                                    UserName = u.UserName,
                                                    CategoryID = u.CategoryID,
                                                    Login = u.Login,
                                                    Password = u.Password
                                                });
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clerk_Zone clerkZone = new Clerk_Zone
                {
                    ClerkID = (cbUser.SelectedItem as User).UserID,
                    ZoneID = (cbZone.SelectedItem as ClimatZone).ZoneID
                };
                DBConnect.connection.Clerk_Zone.Add(clerkZone);
                DBConnect.connection.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                NavigationService.Navigate(new PageWorkZones());
            }

        }
            
        
    }
}
