using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chat.Db.Repositories;
using Chat.Web.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Chat.Web.Areas
{
    /// <summary>
    /// Хаб чата
    /// </summary>
    [HubName("chathub")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        private static readonly List<User> _users = new List<User>();
        //private static readonly IMessagesRepository _messagesRepository = new MessagesRepository();

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="userId">Id соединения пользователя</param>
        /// <param name="text">Текст сообщения</param>
        [HubMethodName("sendMessage")]
        public void SendMessage(string userId, string text)
        {
            Clients.All.getMessage(userId, text, DateTime.Now);

            //var user = _users.FirstOrDefault(x => x.ConnectionId == userId);
            //var message = new Message { SendingTime = DateTime.Now, Text = text, UserName = user?.Name};
            //_messagesRepository.SaveAsync(message);
        }

        /// <summary>
        /// Присоединение пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        [HubMethodName("onConnected")]
        public void OnConnected(string userName)
        {
            var id = Context.ConnectionId;

            if (_users.Any(x => x.ConnectionId == id))
                return;

            Clients.Caller.onConnected(id, _users);
            Clients.AllExcept(id).onNewUserConnected(id, userName);

            var user = new User {ConnectionId = id, Name = userName};
             _users.Add(user);
        }

        /// <summary>
        /// Отключение пользователя
        /// </summary>
        /// <param name="stopCalled">Перестал отвечать?</param>
        /// <returns></returns>
        [HubMethodName("onDisconnected")]
        public override Task OnDisconnected(bool stopCalled)
        {
            var item = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item == null)
                return base.OnDisconnected(stopCalled);

            _users.Remove(item);

            var id = Context.ConnectionId;
            Clients.All.onUserDisconnected(id);

            return base.OnDisconnected(stopCalled);
        }
    }
}