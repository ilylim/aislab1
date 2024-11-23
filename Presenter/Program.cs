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
            // WinForms views
            var addForm = new AddStudentForm();
            var updateForm = new ChangeStudentForm();
            var startForm = new StartForm(addForm, updateForm);

            // Console view
            var consoleView = new ConsoleView();

            // Managers
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            var studentsManager = ninjectKernel.Get<StudentsManager>();
            
            // Starters
            IStarter winFormsStarter = new WinFormsApp.Starter(startForm);
            IStarter consoleStarter = new aislab1.Starter(consoleView);

            // Presenters
            StudentConsolePresenter consolePresenter = new StudentConsolePresenter(consoleView, studentsManager);
            StudentAddPresenter addStudentPresenter = new StudentAddPresenter(addForm, studentsManager);
            StudentDeletePresenter deleteStudentPresenter = new StudentDeletePresenter(startForm, studentsManager);
            StudentUpdatePresenter updateStudentPresenter = new StudentUpdatePresenter(updateForm, studentsManager);

            // Transfer for change views
            TransferConsoleWinForms transferViews = new TransferConsoleWinForms(consoleStarter, winFormsStarter);

            studentsManager.ReadAll(); // Запускаем для того чтобы загрузить инфу с БДшки в приложухи

            // Choose your option
            consoleStarter.StartView();
            //winFormsStarter.StartView();
        }
    }
}
