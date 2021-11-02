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
        public ObservableCollection<Category> categories { get; set; }
        public HomeWindow(User user)
        {
            
            InitializeComponent();
            categories = new ObservableCollection<Category>(DBConnect.connection.Category.ToList());
            var u = from c in categories
                    where user.CategoryID == c.CategoryId
                    select new String(c.CategoryName.ToCharArray());

            foreach (var u_ in u)
                tbUser.Text = $"{u_}: {user.UserName}";

            Frame_full.NavigationService.Navigate(new PageZoneSelect());
        }
        public HomeWindow()
        {
            InitializeComponent();

            Frame_full.NavigationService.Navigate(new PageZoneSelect());
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
