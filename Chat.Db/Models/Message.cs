using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Db.Models
{
    /// <summary>
    /// Класс сообщения
    /// </summary>
    public class Message: IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime SendingTime { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя отправившего пользователя
        /// </summary>
        public string UserName { get; set; }
    }
}
