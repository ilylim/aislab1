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

        public IView View { get; set; }

        public Starter(IView view)
        {
            View = view;
        }

        public void StartView()
        {
            if (IsLoad)
            {
                IsLoad = false;
                Application.EnableVisualStyles();
                ((Form)View).ShowDialog();
            }
            else
            {
                ((Form)View).Visible = true;
            }
        }
    }
}
