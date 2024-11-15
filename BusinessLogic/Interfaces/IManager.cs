using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IManager<T> where T : class
    {
        /// <summary>
        /// Событие оповещения об изменении коллекции T
        /// </summary>
        event Action<IEnumerable<T>> DataChanged;
        /// <summary>
        /// Метод создания сущности
        /// </summary>
        /// <param name="obj"></param>
        void Create(T obj);
        /// <summary>
        /// Метод вывода сущностей
        /// </summary>
        void ReadAll();
        /// <summary>
        /// Метод обновления сущности
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);
        /// <summary>
        /// Метод удаления сущности
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
    }
}
