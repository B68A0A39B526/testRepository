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
    /// Interaction logic for Hospital2GroundFloor.xaml
    /// </summary>
    public partial class Hospital2GroundFloor : Page
    {
        private int numRoom;

        public Hospital2GroundFloor()
        {
            InitializeComponent();
        }

        private void ExaminationRoom1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 1;
            VisibilityOn();
        }

        private void ExaminationRoom2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 2;
            VisibilityOn();
        }

        private void ExaminationRoom3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 3;
            VisibilityOn();
        }

        private void PhysicalTherapyRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 4;
            VisibilityOn();
        }

        private void ExaminationRoom4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 5;
            VisibilityOn();
        }

        private void ExaminationRoom5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 6;
            VisibilityOn();
        }

        private void ExaminationRoom6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 7;
            VisibilityOn();
        }

        private void EmergencyRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numRoom = 8;
            VisibilityOn();
        }

        private void ButtonConfrim_Click(object sender, RoutedEventArgs e)
        {
            switch (numRoom)
            {
                case 1:
                    labelExaminationRoom1.Content = txtNewPurpose.Text;
                    break;
                case 2:
                    labelExaminationRoom2.Content = txtNewPurpose.Text;
                    break;
                case 3:
                    labelExaminationRoom3.Content = txtNewPurpose.Text;
                    break;
                case 4:
                    labelPhysicalTherapyRoom.Content = txtNewPurpose.Text;
                    break;
                case 5:
                    labelExaminationRoom4.Content = txtNewPurpose.Text;
                    break;
                case 6:
                    labelExaminationRoom5.Content = txtNewPurpose.Text;
                    break;
                case 7:
                    labelExaminationRoom6.Content = txtNewPurpose.Text;
                    break;
                case 8:
                    labelEmergencyRoom.Content = txtNewPurpose.Text;
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