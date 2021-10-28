using System;
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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var u = new User();
            u.Name = txtNAme.Text;
            u.Login = txtLogin.Text;
            u.password = txtPassword.Password;
            DBConnect.connection.User.Add(u);
            DBConnect.connection.SaveChanges();
            MessageBox.Show("All ok");
            NavigationService.GoBack();
        }
    }
}
