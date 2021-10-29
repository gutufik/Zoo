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
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public PageAuth()
        {
            InitializeComponent();
        }
        public static ObservableCollection<Clerk> users { get; set; }
        private void loginClick(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<Clerk>(DBConnect.connection.Clerk.ToList());
            var z = users.Where(a => a.Login == txtLogin.Text && a.Password == txtPassword.Password).FirstOrDefault();
            if (z != null)
            {
                MessageBox.Show(z.ClerkName);
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
