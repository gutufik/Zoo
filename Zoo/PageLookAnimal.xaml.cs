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
    /// Логика взаимодействия для PageLookAnimal.xaml
    /// </summary>
    public partial class PageLookAnimal : Page
    {
        public string image { get; set; }
        public PageLookAnimal(Animal animal)
        {
            InitializeComponent();
            this.DataContext = this;
            image = animal.AnimalImage;
        }
    }
}
