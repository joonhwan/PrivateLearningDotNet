using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRWinFormClient
{
    public partial class MainForm : Form
    {
        private HubConnection _hub;
        private IHubProxy _myHubProxy;
        private SynchronizationContext _sync;

        public MainForm()
        {
            InitializeComponent();

            _sync = SynchronizationContext.Current;
            _hub = new HubConnection("http://localhost:28080");
            _myHubProxy = _hub.CreateHubProxy("myHub");
            _myHubProxy.On<string, string>("addMessage", (name, message) =>
            {
                var log = string.Format("> {0} : {1}{2}", name, message, Environment.NewLine);
                _sync.Send(state =>
                {
                    logTextBox.AppendText(log);
                }, null);
            });

            Load += (sender, args) =>
            {
                _hub.Start().Wait();
                logTextBox.Text = "Connected" + Environment.NewLine;
            };

            sendButton.Click += (sender, args) =>
            {
                var user = userNameTextBox.Text;
                var message = messageTextBox.Text;
                _myHubProxy.Invoke("Send", user, message);
            };
        }
    }
}
