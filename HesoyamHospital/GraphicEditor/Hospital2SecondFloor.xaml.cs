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
    /// Interaction logic for Hospital2SecondFloor.xaml
    /// </summary>
    public partial class Hospital2SecondFloor : Page
    {
        private int numRoom;
        public Hospital2SecondFloor()
        {
            InitializeComponent();
        }

        private void PatientRoom1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 1;
            VisibilityOn();
        }

        private void Gynecology_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 2;
            VisibilityOn();
        }

        private void PatientRoom2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 3;
            VisibilityOn();
        }

        private void NurseyRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 4;
            VisibilityOn();
        }

        private void DeliveryRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 5;
            VisibilityOn();
        }

        private void Pediatrics_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 6;
            VisibilityOn();
        }

        private void OnCallRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 7;
            VisibilityOn();
        }
        private void ButtonConfrim_Click(object sender, RoutedEventArgs e)
        {
            switch (numRoom)
            {
                case 1:
                    labelPatientRoom1.Content = txtNewPurpose.Text;
                    break;
                case 2:
                    labelGynecology.Content = txtNewPurpose.Text;
                    break;
                case 3:
                    labelPatientRoom2.Content = txtNewPurpose.Text;
                    break;
                case 4:
                    labelNurseyRoom.Content = txtNewPurpose.Text;
                    break;
                case 5:
                    labelDeliveryRoom.Content = txtNewPurpose.Text;
                    break;
                case 6:
                    labelPediatrics.Content = txtNewPurpose.Text;
                    break;
                case 7:
                    labelOnCallRoom.Content = txtNewPurpose.Text;
                    break;
                default:
                    break;
            }

            VisibilityOff();
            ClearTxt();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            VisibilityOff();
            ClearTxt();
        }

        private void VisibilityOn()
        {
            labelNewPurpose.Visibility = Visibility.Visible;
            txtNewPurpose.Visibility = Visibility.Visible;
            buttonConfrim.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
        }

        private void VisibilityOff()
        {
            labelNewPurpose.Visibility = Visibility.Hidden;
            txtNewPurpose.Visibility = Visibility.Hidden;
            buttonConfrim.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Hidden;
        }

        private void ClearTxt()
        {
            txtNewPurpose.Text = "";
        }
    }
}
