using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCP.Contracts;
using SCP.Proxies;

namespace SCP.Client
{
    public partial class MainForm : Form, ILongRunningCallback
    {
        private readonly LongRunningDuplexClient _service;
        private bool _isCancelled;

        public MainForm()
        {
            InitializeComponent();
            _service = new LongRunningDuplexClient(this);

            Load += (sender, args) =>
            {
                _service.Connect();
            };

            Closing += (sender, args) =>
            {
                //_service.Close(); 
                _service.Disconnect();

                _service.Close();
            };
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _isCancelled = false;

            //var service = new LongRunningClient();
            //service.StartProcess();
            //service.Close(); // StartProcess()가 isOneWay이더라도, Close()는 이전 StartProcess()의 수행이 끝나기 전까지 lock.

            _service.StartProcess();
        }

        public bool ReportNumber(int number)
        {
            logTextBox.AppendText(string.Format("{0} {1}{2}", DateTime.Now.ToString("u"), number, Environment.NewLine));
            //return false; // keep going! 을 의미.
            return _isCancelled;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _isCancelled = true;
        }
    }
}
