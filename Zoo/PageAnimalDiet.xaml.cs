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
    /// Interaction logic for PageAnimalDiet.xaml
    /// </summary>
    public partial class PageAnimalDiet : Page
    {
        public ObservableCollection<Diet> diets { get; set; }
        public ObservableCollection<FeedType> feedTypes { get; set; }
        public IEnumerable<AnimalDiet> animalDiets { get; set; }
        public PageAnimalDiet(Animal animal)
        {
            InitializeComponent();
            diets = new ObservableCollection<Diet>(DBConnect.connection.Diet.ToList());
            feedTypes = new ObservableCollection<FeedType>(DBConnect.connection.FeedType.ToList());
            this.DataContext = this;
            
            animalDiets = from d in diets
                          join ft in feedTypes
                          on d.FeedTypeID equals ft.FeedTypeID
                          where d.AnimalID == animal.AnimalID
                          select new AnimalDiet
                          {
                              AnimalName = animal.AnimalName,
                              date = d.Date,
                              FeedType = ft.FeedTypeName,
                              Weight = (int)d.Weight

                          };


        }
    }

    public class AnimalDiet
    { 
        public string AnimalName { get; set; }
        public DateTime date { get; set; }
        public string FeedType { get; set; }
        public int Weight { get; set; }
    }
}
