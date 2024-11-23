using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace aislab1
{
    internal static class Program
    {
        static void Main()
        {

        }
    }

    public class Starter : IStarter
    {
        public IView View { get; set; }

        public Starter(IView view)
        {
            View = view;
        }

        /// <summary>
        /// Метод показа вьюшки
        /// </summary>
        public void StartView()
        {
            ((ConsoleView)View).Main();
        }
    }
}
