﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IDeleteView: IView
    {
        /// <summary>
        /// Событие удаления сущности
        /// </summary>
        event Action<int> DeleteDataEvent;
    }
}
