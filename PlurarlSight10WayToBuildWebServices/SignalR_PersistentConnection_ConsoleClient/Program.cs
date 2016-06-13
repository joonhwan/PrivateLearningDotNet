﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalR_PersistentConnection_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the service
            var connection = new Connection("http://localhost:28081/echo");

            // Print the message when it comes in
            connection.Received += data => Console.WriteLine(data);

            // Start the connection
            connection.Start().Wait();

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                // Send a message to the server
                connection.Send(line).Wait();
            }
        }
    }
}
