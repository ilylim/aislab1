using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp;
using Ninject;
using Shared;

namespace Presenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var addView = new AddStudentForm();
            var updateView = new ChangeStudentForm();
            var startView = new StartForm(addView, updateView);
            addView.main = startView;
            updateView.main = startView;

            ViewArgs views = new ViewArgs(addView, startView, updateView);

            StudentPresenter presenter = new StudentPresenter(views, new StudentsManager());

            Starter.StartForm(startView);
            Console.ReadKey();
        }
    }
}
