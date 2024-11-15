using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IUpdateView: IView
    {
        /// <summary>
        /// Событие обновления сущности
        /// </summary>
        event Action<EventArgs> UpdateDataEvent;
    }
}
