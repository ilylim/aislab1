using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace WinFormsApp
{
    internal static class Program
    {
        static void Main()
        {
        }
    }
    
    public class Starter : IStarter
    {
        bool IsLoad = true;
        public Starter(IView view) 
        {
            View = view;
        }
        public IView View { get; set; }

        public void StartView()
        {
            Application.EnableVisualStyles();
            ((Form)View).ShowDialog();
        }
    }
}
