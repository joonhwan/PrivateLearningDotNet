using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaultReport.Service;

namespace FaultReport.Client
{
    public partial class MainForm : Form
    {
        private OneWayClient _service;

        public MainForm()
        {
            InitializeComponent();

            _service = new OneWayClient();

            Closing += (sender, args) =>
            {
                _service.Close();
            };
        }

        private void makeCallButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";

            _service.TestOperation();

            messageLabel.Text = "DONE";
        }
    }
}
