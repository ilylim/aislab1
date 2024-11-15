using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ViewArgs //класс для передачи параметров конструктора презентера
    {
        public IAddView addView { get; set; }
        public IDeleteView deleteView { get; set; }
        public IUpdateView updateView { get; set; }
        public ViewArgs(IAddView addView, IDeleteView deleteView, IUpdateView updateView)
        {
            this.addView = addView;
            this.deleteView = deleteView;
            this.updateView = updateView;
        }
    }
}
