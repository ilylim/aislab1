﻿using BusinessLogic;
using Entities;
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
            IKernel ninjectKernelWinFormsView = new StandardKernel(new WinFormsViewConfigModule());
            var startForm = ninjectKernelWinFormsView.Get<IMainWinFormsView>();

            // Console view
            IKernel ninjectKernelConsoleView = new StandardKernel(new ConsoleViewConfigModule());
            var consoleView = ninjectKernelConsoleView.Get<IConsoleView>();

            // Managers
            IKernel ninjectKernel = new StandardKernel(new BusinessLogicConfigModule());
            var studentsManager = ninjectKernel.Get<IManager<Student>>();
            
            // Starters
            IStarter winFormsStarter = new WinFormsApp.Starter(startForm);
            IStarter consoleStarter = new aislab1.Starter(consoleView);

            // Presenters
            StudentConsolePresenter consolePresenter = new StudentConsolePresenter(consoleView, studentsManager);
            StudentAddPresenter addStudentPresenter = new StudentAddPresenter(startForm.addView, studentsManager);
            StudentDeletePresenter deleteStudentPresenter = new StudentDeletePresenter(startForm.deleteView, studentsManager);
            StudentUpdatePresenter updateStudentPresenter = new StudentUpdatePresenter(startForm.updateView, studentsManager);

            // Transfer for change views
            TransferConsoleWinForms transferViews = new TransferConsoleWinForms(consoleStarter, winFormsStarter);

            studentsManager.ReadAll(); // Запускаем для того чтобы загрузить инфу с БДшки в приложухи

            // Choose your option
            consoleStarter.StartView();
            //winFormsStarter.StartView();
        }
    }
}
