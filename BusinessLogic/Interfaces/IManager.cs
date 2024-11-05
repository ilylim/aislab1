using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface IManager<T>
    {
        void Create(T obj);
        void ReadAll();
        void Update(int Id, T obj);
        void Delete(int Id);
    }
}
