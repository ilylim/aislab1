using aislab1;
using BusinessLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp;

namespace Presenter
{
    internal class TransitionPresenter
    {
        private IStarter ConsoleStarter;
        private IStarter WinFormsStarter;

        public TransitionPresenter(IStarter consoleStarter, IStarter winFormsStarter)
        {
            WinFormsStarter = winFormsStarter;
            ((ITransitionView)WinFormsStarter.View).ChangeView += ChangeWFView;

            ConsoleStarter = consoleStarter;
            ((ITransitionView)ConsoleStarter.View).ChangeView += ChangeConsoleView;
        }

        private void ChangeWFView()
        {
            StudentsManager studentsManager = new StudentsManager();
            ConsoleView consoleView = new ConsoleView();
            StudentConsolePresenter consolePresenter = new StudentConsolePresenter(consoleView, studentsManager);

            ConsoleStarter.View = consoleView;
            ((ITransitionView)ConsoleStarter.View).ChangeView += ChangeConsoleView;

            ConsoleStarter.StartView();
        }

        private void ChangeConsoleView()
        {
            StudentsManager studentsManager = new StudentsManager();
            StartForm startView = new StartForm(new AddStudentForm(), new ChangeStudentForm());
            StudentDeletePresenter startPresenter = new StudentDeletePresenter(startView, studentsManager);
            StudentAddPresenter addPresenter = new StudentAddPresenter(startView.addStudentView, studentsManager);
            StudentUpdatePresenter updatePresenter = new StudentUpdatePresenter(startView.updateStudentView, studentsManager);

            WinFormsStarter.View = startView;
            ((ITransitionView)WinFormsStarter.View).ChangeView += ChangeWFView;

            WinFormsStarter.StartView();
        }
    }
}
