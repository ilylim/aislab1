using aislab1;
using BusinessLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp;
using Entities;
using Ninject;

namespace Presenter
{
    internal class TransferConsoleWinForms
    {
        private IStarter ConsoleStarter;
        private IStarter WinFormsStarter;

        /// <summary>
        /// Метод создания экземпляра TransitionPresenter
        /// </summary>
        /// <param name="consoleStarter">стартер c ITransitionView консольной вьюшки</param>
        /// <param name="winFormsStarter">стартер с ITransitionView вьюшки винформсов</param>
        public TransferConsoleWinForms(IStarter consoleStarter, IStarter winFormsStarter)
        {
            ConsoleStarter = consoleStarter;
            WinFormsStarter = winFormsStarter;

            // Предполагается, что в стартерах вьюшки являются изменяемыми (ITransitionView)
            ((ITransitionView)ConsoleStarter.View).ChangeView += ChangeConsoleView;
            ((ITransitionView)WinFormsStarter.View).ChangeView += ChangeWinFormsView;
        }

        /// <summary>
        /// Метод переклчения консольной вьюшки на винформс
        /// </summary>
        private void ChangeConsoleView()
        {
            WinFormsStarter.StartView();
        }

        /// <summary>
        /// Метод переключения винформс вьюшки на консоль
        /// </summary>
        private void ChangeWinFormsView()
        {
            ConsoleStarter.StartView();
        }
    }
}
