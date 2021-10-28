using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    
    public partial class Page2 : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public Page2()
        {
            InitializeComponent();
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            var z = users.Where(a => a.Login == txtLogin.Text && a.password == txtPassword.Password).FirstOrDefault();
            if (z != null)
            {
                MessageBox.Show(z.Name);
            }
            else
            {
                MessageBox.Show("Invalid User", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void registerClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }
    }
}
