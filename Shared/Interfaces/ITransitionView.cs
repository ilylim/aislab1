using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ITransitionView : IView // Интерфейс для переключаемых вьюшек
    {
        /// <summary>
        /// Событие переключения между вьюшками
        /// </summary>
        event Action ChangeView;
    }
}
