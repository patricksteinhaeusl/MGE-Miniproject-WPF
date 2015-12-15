using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace ch.hsr.wpf.gadgeothek.admin
{
    class AdminController
    {
        private String serverUrl;
        private LibraryAdminService las;

        public AdminController(String serverUrl)
        {
            this.serverUrl = serverUrl;
            this.las = new LibraryAdminService(serverUrl);
        }

        public void loadDataGrids()
        {
            loadDataGridCustomers();
        }

        public void loadDataGridCustomers()
        {
            List<Gadget> list = las.GetAllGadgets();
            dataGridCustomers.ItemSource = list;
        }
    }
}
