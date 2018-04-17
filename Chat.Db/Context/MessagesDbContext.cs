using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Db.Models;

namespace Chat.Db.Context
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    internal partial class MessagesDbContext: DbContext
    {
        /// <summary>
        /// Коллекция Собщений
        /// </summary>
        public DbSet<Message> Messages { get; set; }
    }
}
