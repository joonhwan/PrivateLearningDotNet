using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfRoutingCbr.Service;

namespace WcfRoutingCbr.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            var code = Int32.Parse(zipCodeTextBox.Text);
            try
            {
                var service = new GeoClient();
                var state = service.GetStateNameByZipCode(code);
                stateLabel.Text = state;
            }
            catch (Exception ex)
            {
                stateLabel.Text = ex.Message;
            }
        }
    }
}
