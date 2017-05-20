using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AI.Learning.API.Hubs
{
    public class LearningHub: Hub
    {
        public void SendResponse(string message)
        {
            // Call the broadcastResponse method to update clients.
            Clients.Caller.broadcastResponse(message);
        }

        public void SendMessage(string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(message);
        }
    }
}