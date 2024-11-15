using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAddView: IView
    {
        /// <summary>
        /// Событие добавления новой сущности
        /// </summary>
        event Action<EventArgs> AddDataEvent;
    }
}
