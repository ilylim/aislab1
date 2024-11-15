using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IView
    {
        /// <summary>
        /// Метод перерисовки вьюхи
        /// </summary>
        /// <param name="args">коллекция с сущностями</param>
        void RedrawForm(IEnumerable<EventArgs> args);
    }
}
