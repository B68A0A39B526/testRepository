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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawingShapesService drawing_shapes = new DrawingShapesService();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> list = graphic_repository.ReadFromFile("hospitalmap.txt");

            foreach (GraphicalObject graphical_object in list)
            {
                Shape shape = drawing_shapes.draw_Shapes(graphical_object);
                canvas1.Children.Add(shape);
            }
        }

        private void Display_Hospital1(object sender, RoutedEventArgs e)
        {
             Hospital1Window hospital1 = new Hospital1Window();
             hospital1.Show();
        }

        private void Display_Hospital2(object sender, RoutedEventArgs e)
        {
             Hospital2Window hospital2 = new Hospital2Window();
             hospital2.Show();
        }

        private void Display_Warehouse(object sender, RoutedEventArgs e)
        {
             WarehouseWindow warehouse = new WarehouseWindow();
             warehouse.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MouseLeftButtonDown_Hospital1(object sender, MouseButtonEventArgs e)
        {
             Hospital1Window hospital1 = new Hospital1Window();
             hospital1.Show();
        }

        private void MouseLeftButtonDown_Hospital2(object sender, MouseButtonEventArgs e)
        {
             Hospital2Window hospital2 = new Hospital2Window();
             hospital2.Show();
        }

        private void MouseLeftButtonDown_Warehouse(object sender, MouseButtonEventArgs e)
        {
             WarehouseWindow warehouse = new WarehouseWindow();
             warehouse.Show();
        }
    }
}
