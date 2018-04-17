using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Db.Models;
using Chat.Db.Repositories;

namespace Chat.Web.Controllers
{
    /// <summary>
    /// Api контроллер сообщений
    /// </summary>
    public class MessagesController : ApiController
    {
        /// <summary>
        /// Репозиторий
        /// </summary>
        private readonly IMessagesRepository _repository;

        /// <summary>
        /// Заглушка без IoC
        /// </summary>
        public MessagesController()
        {
            _repository = new MessagesRepository();
        }

        /// <summary>
        /// Конструтор
        /// </summary>
        /// <param name="repository">Репозиторий сообщений</param>
        public MessagesController(IMessagesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _repository.GetAll();
        }
    }
}
