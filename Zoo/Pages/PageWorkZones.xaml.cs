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

        public PageWorkZones()
        {
            InitializeComponent();
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            climatZones = new ObservableCollection<ClimatZone>(DBConnect.connection.ClimatZone.ToList());
            clerk_Zones = new ObservableCollection<Clerk_Zone>(DBConnect.connection.Clerk_Zone.ToList());
            this.DataContext = this;

            workZones = from cz in clerk_Zones
                        join clz in climatZones
                        on cz.ZoneID equals clz.ZoneID
                        join u in users
                        on cz.ClerkID equals u.UserID
                        select new WorkZone
                        {
                            ClerkName = u.UserName,
                            ZoneName = clz.ZoneName
                        };

        }
    }
    public class WorkZone
    { 
        public string ClerkName { get; set; }
        public string ZoneName { get; set; }
    }
}
