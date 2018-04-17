using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    /// <summary>
    /// Сущность в БД
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        long Id { get; set; }
    }
}
