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
    /// Логика взаимодействия для PageClerks.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public static ObservableCollection<Category> categories { get; set; }
        public static IEnumerable<UserCategory> users_ { get; set; }
        public PageUsers()
        {
            InitializeComponent();
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            categories = new ObservableCollection<Category>(DBConnect.connection.Category.ToList());

            users_ = from u in users
                    join c in categories
                    on u.CategoryID equals c.CategoryId
                    select new UserCategory
                    {
                        UserID = u.UserID,
                        UserName = u.UserName,
                        Login = u.Login,
                        Password = u.Password,
                        CategoryName = c.CategoryName
                    };
            this.DataContext = this;
        }

        private void dg_Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_UserDel.IsEnabled = true;
        }

        private void btn_UserDel_Click(object sender, RoutedEventArgs e)
        {
            var user = dg_Users.SelectedItem as UserCategory;
            DBConnect.connection.User.Remove(DBConnect.connection.User.Find(user.UserID));
            DBConnect.connection.SaveChanges();
            NavigationService.Navigate(new PageUsers());
        }

        private void btn_UserAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }
    }
    public class UserCategory
    { 
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CategoryName { get; set; }

    }
}
