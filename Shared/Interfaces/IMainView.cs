using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IMainView : IView // Интерфейс для главной вьюшки (если в процессе из неё вызываются другие вьюшки)
    {
        IAddView addView { get; set; }
        IUpdateView updateView { get; set; }
        IDeleteView deleteView { get; set; }
    }
}
