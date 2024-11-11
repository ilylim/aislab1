using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface IManager<T>
    {
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
        /// <param name="Id"></param>
        /// <param name="obj"></param>
        void Update(int Id, T obj);
        /// <summary>
        /// Метод удаления сущности
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
    }
}
