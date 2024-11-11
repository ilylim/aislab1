using BusinessLogic;
using Ninject;

namespace WinFormsApp
{
    internal class LogicDTO //Класс Data Transfer Object для взаимодействия разных форм с одной логикой
    {
        private static IKernel ninjectKernel = new StandardKernel(new SampleConfigModule());
        public static StudentsManager studentsManager { get; set; } = ninjectKernel.Get<StudentsManager>();
    }
}
