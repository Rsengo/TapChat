using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Web.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID подключения
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
    }
}
