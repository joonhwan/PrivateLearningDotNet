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
using SignalRMyHub;

namespace SignalRWinFormClient
{
    public partial class MainForm : Form
    {
        private HubConnection _hub;
        private IHubProxy<IMyHubServer, IMyHubClient> _myHubProxy;
        private SynchronizationContext _sync;

        public MainForm()
        {
            InitializeComponent();

            _sync = SynchronizationContext.Current;
            _hub = new HubConnection("http://localhost:28080");
            //_myHubProxy = _hub.CreateHubProxy("myHub");
            //_myHubProxy.On<string, string>("AddMessage", (name, message) =>
            //{
            //    var log = string.Format("> {0} : {1}{2}", name, message, Environment.NewLine);
            //    _sync.Send(state =>
            //    {
            //        logTextBox.AppendText(log);
            //    }, null);
            //});
            _myHubProxy = _hub.CreateHubProxy<IMyHubServer, IMyHubClient>("myHub");
            _myHubProxy.SubscribeOn<string, string>(client => client.AddMessage, (name, message) =>
            {
                var log = string.Format("> {0} : {1}{2}", name, message, Environment.NewLine);
                _sync.Post(state =>
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
                //_myHubProxy.Invoke("Send", user, message);
                _myHubProxy.Call(server => server.Send(user, message));
            };
        }
    }
}
