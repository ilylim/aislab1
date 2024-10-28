using BusinessLogic;

namespace WinFormsApp
{
    internal class LogicDTO //Класс Data Transfer Object для взаимодействия разных форм с одной логикой
    {
        public static Logic Logic { get; set; }
    }
}
