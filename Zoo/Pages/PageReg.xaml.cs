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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    
    public partial class PageReg : Page
    {
        public static ObservableCollection<Category> categories { get; set; }
        int i { get; set; }
        PageUsers page { get; set; }
        public PageReg()
        {
            InitializeComponent();
            categories = new ObservableCollection<Category>(DBConnect.connection.Category.ToList());
            this.DataContext = this;
        }
        public PageReg(PageUsers page)
        {
            InitializeComponent();
            categories = new ObservableCollection<Category>(DBConnect.connection.Category.ToList());
            this.DataContext = this;
            this.page = page;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            var u = new User();
            if (i != 0)
            {
                u.UserName = txtName.Text;
                u.Login = txtLogin.Text;
                u.Password = txtPassword.Password;
                u.CategoryID = i;
                DBConnect.connection.User.Add(u);
                DBConnect.connection.SaveChanges();
                MessageBox.Show("All ok");
                if (page != null)
                {
                    NavigationService.Navigate(new PageUsers());
                }
                else
                {
                    NavigationService.GoBack();
                }
            }
            else 
            {
                MessageBox.Show("Invalid User", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Category;
            i = a.CategoryId;
        }
    }
}
