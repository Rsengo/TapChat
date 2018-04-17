using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Db.Models;

namespace Chat.Db.Repositories
{
    /// <summary>
    /// Обобщенный репозиторий
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public interface IGenericRepository<TEntity> where TEntity: IEntity
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Сохранить объекты сущности
        /// </summary>
        /// <param name="entities">Объекты сущности</param>
        void Save(params TEntity[] entities);

        /// <summary>
        /// Сохранить объекты сущности асинхронно
        /// </summary>
        /// <param name="entities">Объекты сущности</param>
        /// <returns></returns>
        Task SaveAsync(params TEntity[] entities);
    }
}
