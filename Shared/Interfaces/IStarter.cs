using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IStarter // Интерфейс стартеров
    {
        IView View { get; set; }
        /// <summary>
        /// Метод запуска вьюшки
        /// </summary>
        void StartView();
    }
}
