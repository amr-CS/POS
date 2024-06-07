using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace appSchoolCalling.signalr.hubs
{
    public class ChatHub : Hub
    {

        public static string vSendMessage;
        public void Send(string message)
        {
            vSendMessage = message;
            Clients.All.addNewMessageToPage(message);
        }

    }
}