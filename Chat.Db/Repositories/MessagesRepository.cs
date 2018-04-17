using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Db.Context;
using Chat.Db.Models;

namespace Chat.Db.Repositories
{
    /// <summary>
    /// Репозиторий сообщений
    /// </summary>
    public class MessagesRepository: IMessagesRepository
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Message> GetAll()
        {
            using (var context = new MessagesDbContext())
            {
                return context.Messages;
            }
        }

        /// <summary>
        /// Сохранить объекты сущности
        /// </summary>
        /// <param name="entities">Объекты сущности</param>
        public void Save(params Message[] entities)
        {
            using (var context = new MessagesDbContext())
            {
                context.Messages.AddRange(entities);
            }
        }

        /// <summary>
        /// Сохранить объекты сущности асинхронно
        /// </summary>
        /// <param name="entities">Объекты сущности</param>
        /// <returns></returns>
        public async Task SaveAsync(params Message[] entities)
        {
            using (var context = new MessagesDbContext())
            {
                await Task.Run(() => context.Messages.AddRange(entities));
                await context.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// Интерфейс репозитория сообщений
    /// </summary>
    public interface IMessagesRepository: IGenericRepository<Message>
    { }
}
