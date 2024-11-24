using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IMainWinFormsView : IView
    {
        IAddView addView { get; set; }
        IUpdateView updateView { get; set; }
        IDeleteView deleteView { get; set; }
    }
}
