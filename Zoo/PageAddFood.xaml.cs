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
    /// Логика взаимодействия для PageAddFood.xaml
    /// </summary>
    public partial class PageAddFood : Page
    {
        public ObservableCollection<FeedType> feedTypes { get; set; }
        private Animal animal;
        public PageAddFood(Animal animal)
        {
            this.animal = animal;
            InitializeComponent();
            feedTypes = new ObservableCollection<FeedType>(DBConnect.connection.FeedType.ToList());
            this.DataContext = this;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Diet diet = new Diet
                {
                    AnimalID = animal.AnimalID,
                    Date = (DateTime)dpDate.SelectedDate,
                    FeedTypeID = (cbType.SelectedItem as FeedType).FeedTypeID,
                    Weight = int.Parse(tbWeight.Text),

                };
                DBConnect.connection.Diet.Add(diet);
                DBConnect.connection.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally 
            {
                NavigationService.Navigate(new PageAnimalDiet(animal));
            }
        }
    }
}
