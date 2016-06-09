using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaultReport.Service;

namespace FaultReport.Client
{
    public partial class MainForm : Form, IOneWayExceptionCallback
    {
        private OneWayClient _service;

        public MainForm()
        {
            InitializeComponent();

            _service = new OneWayClient(this);

            Closing += (sender, args) =>
            {
                _service.Close();
            };
        }

        private void makeCallButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            try
            {
                _service.TestOperation();
                messageLabel.Text = "DONE";
            }
            catch (FaultException<ArgumentException> ex)
            {
                MessageBox.Show("Exception is caught!");
                messageLabel.Text = "";
            }
        }

        public void ReportError(Exception ex)
        {
            //MessageBox.Show(string.Format("Exception has been caught! : {0]", ex.Message));
            throw ex;
        }
    }
}
