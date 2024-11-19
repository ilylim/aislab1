using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp;
using Ninject;
using Shared;
using aislab1;

namespace Presenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WinForms views
            var startView = new StartForm(new AddStudentForm(), new ChangeStudentForm()); 

            //Console view
            var consoleView = new ConsoleView();

            //Managers
            var studentsManager = new StudentsManager();

            //Starters
            IStarter winFormsStarter = new WinFormsApp.Starter(startView);
            IStarter consoleStarter = new aislab1.Starter(consoleView);

            //Presenters
            StudentDeletePresenter startPresenter = new StudentDeletePresenter(startView, studentsManager);
            StudentAddPresenter addPresenter = new StudentAddPresenter(startView.addStudentView, studentsManager);
            StudentUpdatePresenter updatePresenter = new StudentUpdatePresenter(startView.updateStudentView, studentsManager);
            StudentConsolePresenter consolePresenter = new StudentConsolePresenter(consoleView, studentsManager);

            TransitionPresenter transitionPresenter = new TransitionPresenter(consoleStarter, winFormsStarter);

            consoleStarter.StartView();
        }
    }
}
