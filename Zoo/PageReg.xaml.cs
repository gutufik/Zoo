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
        public PageReg()
        {
            InitializeComponent();
            categories = new ObservableCollection<Category>(DBConnect.connection.Category.ToList());
            this.DataContext = this;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAuth());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var u = new Clerk();
            u.ClerkName = txtName.Text;
            u.Login = txtLogin.Text;
            u.Password = txtPassword.Password;
            u.CategoryID = i;
            DBConnect.connection.Clerk.Add(u);
            DBConnect.connection.SaveChanges();
            MessageBox.Show("All ok");
            NavigationService.GoBack();
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Category;
            i = a.CategoryId;
        }
    }
}
