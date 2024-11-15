using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
        }
    }
    
    public static class Starter
    {
        public static void StartForm(StartForm form)
        {
            Application.EnableVisualStyles();
            Application.Run(form);
        }
    }
}
