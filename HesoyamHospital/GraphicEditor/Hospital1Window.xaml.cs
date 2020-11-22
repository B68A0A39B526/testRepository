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
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital1Window.xaml
    /// </summary>
    public partial class Hospital1Window : Window
    {
        public Hospital1Window()
        {
            InitializeComponent();
            Hospital1.Content = new Hospital1GroundFloor();
            Hospital1_GroundFloor.IsSelected = true;
        }

        private void Hospital1_SelectionChangedFloor(object sender, SelectionChangedEventArgs e)
        {

            if (Hospital1_GroundFloor.IsSelected)
            {
                Hospital1.Content = new Hospital1GroundFloor();
            }
            else
            {
                Hospital1.Content = new Hospital1FirstFloor();
            }

        }
    }
}
