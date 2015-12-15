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

namespace ch.hsr.wpf.gadgeothek.admin
{
    /// <summary>
    /// Interaction logic for GadgetAdd.xaml
    /// </summary>
    public partial class GadgetAdd : Window
    {
        public GadgetAdd()
        {
            InitializeComponent();
        }

        private void GadgetAddSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if(Name.Text.Length > 0 && Manufacturer.Text.Length > 0 && Price.Text.Length > 0)
            {
                mainWindow.GadgetsAdd(Name.Text, Manufacturer.Text, double.Parse(Price.Text));
                this.Close();
            } else
            {
                labelInfo.Content = "Es sind nicht alle Werte ausgefüllt";
                labelInfo.Height = 25;
            }
        }
    }
}
