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

using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace ch.hsr.wpf.gadgeothek.admin
{
    /// <summary>
    /// Interaction logic for GadgetDelete.xaml
    /// </summary>
    public partial class GadgetDelete : Window
    {
        private Gadget gadget = null;

        public GadgetDelete(Gadget gadget)
        {
            this.gadget = gadget;

            InitializeComponent();
            
            Name.Content = this.gadget.Name.ToString();
            Manufacturer.Content = this.gadget.Manufacturer.ToString();
            Price.Content = this.gadget.Price.ToString();
        }

        private void GadgetDeleteYes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.GadgetDelete(gadget);
            this.Close();
        }

        private void GadgetDeleteNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
