using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatRoomServer.Hubs
{
    public class ChatRoomHub : Hub
    {
        /// <summary>
        /// Receive message from clients and broadcast to all connected clients.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
