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
using System.Configuration;
using System.Diagnostics;
using System.Windows.Threading;

using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace ch.hsr.wpf.gadgeothek.admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String serverUrl;
        private LibraryAdminService las;

        public MainWindow()
        {
            InitializeComponent();

            this.serverUrl = ConfigurationManager.AppSettings["server"];
            this.las = new LibraryAdminService(this.serverUrl);

            loadDataGrids();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(loadDataGridsByTimer);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void loadDataGrids()
        {
            fillDataGrid(DataGridCustomers, this.las.GetAllCustomers());
            fillDataGrid(DataGridGadgets, this.las.GetAllGadgets());
            fillDataGrid(DataGridLoans, this.las.GetAllLoans());
            fillDataGrid(DataGridReservations, this.las.GetAllReservations());
        }

        private void loadDataGridsByTimer(object sender, EventArgs e)
        {
            loadDataGrids();
        }

        private void fillDataGrid<T>(DataGrid DataGrid, List<T> list)
        {
            DataGrid.ItemsSource = list;
        }

        private void GadgetsAdd_Click(object sender, RoutedEventArgs e)
        {
            GadgetAdd gadgetAdd = new GadgetAdd();
            gadgetAdd.Show();
        }

        public void GadgetsAdd(string name, string manufacturer, double price)
        {
            Gadget gadget = new Gadget(name, manufacturer, price);
            las.AddGadget(gadget);
            loadDataGrids();
        }

        private void GadgetsDelete_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridGadgets.SelectedItems.Count > 0)
            {
                Gadget gadget = (Gadget)DataGridGadgets.SelectedItems[0];

                GadgetDelete gadgetDelete = new GadgetDelete(gadget);
                gadgetDelete.Show();
            }
        }

        public void GadgetDelete(Gadget gadget)
        {
            las.DeleteGadget(gadget);
            loadDataGrids();
        }
    }
}
