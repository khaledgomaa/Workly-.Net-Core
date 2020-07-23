using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Workly.Domain;
using Workly.Domain.ViewModels;
using Workly.Service.Interfaces;

namespace Workly.Api.Hubs
{
    public class NotificationSender : Hub
    {
        public async Task SendMessage(int agentId, IEnumerable<NotificationViewModel> message)
        {
            await Clients.Users("ef554148-d531-4c5e-aa7e-79b9c872c8f6").SendAsync("Send", message);
            //await Clients.All.SendAsync("Send", message);
        }
    }
}
