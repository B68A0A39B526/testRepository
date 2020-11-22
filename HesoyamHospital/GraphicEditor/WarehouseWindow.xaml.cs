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
    /// Interaction logic for WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        private int numStorage;
        public WarehouseWindow()
        {
            InitializeComponent();
        }

        private void MedicineStorage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numStorage = 1;
            VisibilityOn();
        }

        private void EquipmentStorage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            numStorage = 2;
            VisibilityOn();
        }


        private void ButtonConfrim_Click(object sender, RoutedEventArgs e)
        {
            switch (numStorage)
            {
                case 1:
                    labelMedicineStorage.Content = txtNewPurpose.Text;
                    break;
                case 2:
                    labelEquipmentStorage.Content = txtNewPurpose.Text;
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
