using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditor
{
    class DrawingShapesService
    {

        public DrawingShapesService()
        {
        }

        public (SolidColorBrush, SolidColorBrush) Pick_color(string type)
        {
            switch (type)
            {
                case "hospital":
                    return (Brushes.Purple, Brushes.Transparent);
                case "warehouse":
                    return (Brushes.Purple, Brushes.Transparent);
                case "floor":
                    return (Brushes.LightGray, Brushes.Transparent);
                case "shop":
                    return (Brushes.Orange, Brushes.Transparent);
                case "bakery":
                    return (Brushes.Orange, Brushes.Transparent);
                case "cafe":
                    return (Brushes.Orange, Brushes.Transparent);
                case "room":
                    return (Brushes.PeachPuff, Brushes.Black);
                case "elevator":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "stairs":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "door":
                    return (Brushes.DarkRed, Brushes.Transparent);
                case "sidewalk":
                    return (Brushes.GhostWhite, Brushes.Transparent);
                case "grass":
                    return (Brushes.Green, Brushes.Transparent);
                case "road":
                    return (Brushes.Gray, Brushes.Transparent);
                case "parking":
                    return (Brushes.Gray, Brushes.Yellow);
                default:
                    return (Brushes.Black, Brushes.Transparent);
            }
        }

        public Shape draw_Shapes(GraphicalObject graphical_object)
        {

            string shape = graphical_object.Shape;
            SolidColorBrush brush;
            SolidColorBrush stroke;
            (brush, stroke) = Pick_color(graphical_object.Type);
            switch (shape)
            {
                case "rectangle":
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = graphical_object.Width;
                    rectangle.Height = graphical_object.Height;
                    rectangle.Fill = brush;
                    rectangle.Name = graphical_object.Name;

                    rectangle.Stroke = stroke;

                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(rectangle, graphical_object.Left);
                    Canvas.SetTop(rectangle, graphical_object.Top);
                    return rectangle;

                case "elipse":
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = graphical_object.Width;
                    ellipse.Height = graphical_object.Height;
                    ellipse.Fill = brush;
                    ellipse.Stroke = stroke;
                    ellipse.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(ellipse, graphical_object.Left);
                    Canvas.SetTop(ellipse, graphical_object.Top);
                    return ellipse;
                default:
                    return new Rectangle();

            }
        }

    }
}
