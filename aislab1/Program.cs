using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace aislab1
{
    internal class Program
    {
        /// <summary>
        /// Метод реализации лабы через меню в консоли
        /// </summary>
        static public void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Logic logic = new Logic();
            logic.GetAllDictionary();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить студента\n2. Удалить студента\n3. Изменить студента\n4. Показать таблицу\n5. Показать гистограмму студентов по специальностям\n6. Выход");
                if (Int32.TryParse(Console.ReadLine(), out int Menu))
                {
                    switch (Menu)
                    {
                        case 1:
                            bool correctName = false;
                            bool correctSpeciality = false;
                            while (!(correctName && correctSpeciality))
                            {
                                Console.Clear();
                                Console.WriteLine("Введите ФИО студента\n\n\nНапишите 9999, если не хотите добавлять студента");
                                string name = Console.ReadLine();
                                if (name == "9999")
                                {
                                    break;
                                }
                                else if (!string.IsNullOrEmpty(name) && int.TryParse(name, out int result) == false && !string.IsNullOrWhiteSpace(name)) //Проверка на дурака
                                {
                                    correctName = true;
                                    Console.Clear();
                                    Console.WriteLine($"ФИО студента: {name}\nВведите группу студента");
                                    string group = Console.ReadLine();
                                    while (!correctSpeciality)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"ФИО студента: {name}\nГруппа студента: {group}\n\nВыберите специализацию студента\n1 - ИСИТ\n2 - ИБ\n3 - ИВТ\n4 - ПИ)");
                                        if (Int32.TryParse(Console.ReadLine(), out int codeSpeciality) && codeSpeciality > 0 && codeSpeciality < 5)
                                        {
                                            switch (codeSpeciality)
                                            {
                                                case 1:
                                                    logic.AddStudent(name, group, "ИСИТ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 2:
                                                    logic.AddStudent(name, group, "ИБ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 3:
                                                    logic.AddStudent(name, group, "ИВТ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 4:
                                                    logic.AddStudent(name, group, "ПИ");
                                                    correctSpeciality = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Такой специальности нет ! Пожалуйста, выберите одну из предложенных");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Придумайте студенту имя не пустое и без цифр...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 2:
                            Console.Clear();
                            PrintList(logic);
                            Console.WriteLine();
                            Console.WriteLine("Введите код студента из списка");
                            if (Int32.TryParse(Console.ReadLine(), out int codeRemovedStudent) && codeRemovedStudent > 0)
                                if (!(logic.Students.Keys.Contains(codeRemovedStudent)))
                                {
                                    Console.WriteLine("Студента с таким кодом не существует !");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    logic.RemoveStudent(codeRemovedStudent);
                                }
                            else
                            {
                                Console.WriteLine("Код студента является числом > 0");
                                Console.ReadKey();
                            }
                            break;

                        case 3:
                            Console.Clear();
                            PrintList(logic);
                            Console.WriteLine();
                            Console.WriteLine("Введите код студента из списка");
                            if (Int32.TryParse(Console.ReadLine(), out int codeChangedStudent) && codeChangedStudent > 0)
                                if (!(logic.Students.Keys.Contains(codeChangedStudent)))
                                {
                                    Console.WriteLine("Студента с таким кодом не существует !");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    bool exitChange = false;
                                    while (!exitChange)
                                    {
                                        Console.WriteLine($"Что изменим ?\n1. ФИО студента\n2. Группу\n3. Специальность\n4. Вернуться назад");

                                        if (Int32.TryParse(Console.ReadLine(), out int changeCode))
                                        {
                                            switch (changeCode)
                                            {
                                                case 1:
                                                    Console.WriteLine("Введите новое ФИО студента");
                                                    string studentNewName = Console.ReadLine();

                                                    logic.ChangeStudent(codeChangedStudent, studentNewName, "", "");
                                                    break;

                                                case 2:
                                                    Console.WriteLine("Введите новую группу студента");
                                                    string studentNewGroup = Console.ReadLine();

                                                    logic.ChangeStudent(codeChangedStudent, "", studentNewGroup, "");
                                                    break;

                                                case 3:
                                                    Console.WriteLine("Введите новую специальность студента (ИСИТ, ИБ, ИВТ, ПИ)");
                                                    bool correctNewSpeciality = false;
                                                    while (!correctNewSpeciality)
                                                    {
                                                        if (Int32.TryParse(Console.ReadLine(), out int codeNewSpeciality) && codeNewSpeciality > 0 && codeNewSpeciality < 5)
                                                        {
                                                            switch (codeNewSpeciality)
                                                            {
                                                                case 1:
                                                                    logic.ChangeStudent(codeChangedStudent, "", "", "ИСИТ");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 2:
                                                                    logic.ChangeStudent(codeChangedStudent, "", "", "ИБ");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 3:
                                                                    logic.ChangeStudent(codeChangedStudent, "", "", "ИВТ");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 4:
                                                                    logic.ChangeStudent(codeChangedStudent, "", "", "ПИ");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Такой специальности нет !");
                                                            Console.ReadKey();
                                                        }
                                                    }
                                                    break;

                                                case 4:
                                                    Console.Clear();
                                                    exitChange = true;
                                                    break;

                                                default:
                                                    Console.WriteLine("Нужно ввести значение от 1 до 4 !");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Студента с таким кодом не существует !");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            else
                            {
                                Console.WriteLine("Код студента является числом > 0");
                                Console.ReadKey();
                            }
                            break;

                        case 4:
                            Console.Clear();
                            PrintList(logic);
                            Console.ReadKey();         
                            break;

                        case 5:
                            Console.Clear();
                            PrintChart(logic);
                            Console.ReadKey();
                            break;

                        case 6:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Введите число от 1 до 6 !");
                            break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Метод вывода таблицы в консоль
        /// </summary>
        /// <param name="logic">бизнеслогика</param>
        static void PrintList(Logic logic)
        {
            Console.Clear();
            List<(int, string, string, string)> studentsInfo = logic.GetAllStudents();
            Console.WriteLine("┌─────────────────────┬─────────────────────┬────────────────────┬────────────────────┐");
            Console.WriteLine("│         Id          │         ФИО         │       Группа       │   Специальность    │");
            Console.WriteLine("├─────────────────────┼─────────────────────┼────────────────────┼────────────────────┤");
            foreach (var student in studentsInfo)
            {
                Console.Write("│ {0, -20}│", student.Item1);
                Console.Write("{0, -20} │", student.Item2);
                Console.Write("{0, -20}│", student.Item3);
                Console.Write("{0, -20}│\n├─────────────────────┼─────────────────────┼────────────────────┼────────────────────┤\n", student.Item4);
            }
            Console.WriteLine("└─────────────────────┴─────────────────────┴────────────────────┴────────────────────┘");
        }

        /// <summary>
        /// Метод вывода гистограммы в консоль
        /// </summary>
        /// <param name="logic">бизнеслогика</param>
        static void PrintChart(Logic logic)
        {
            logic.GetStudentsSpecialities();
            Console.WriteLine("╔═════════════════════════╗");
            int maxStudents = logic.countStudentsSpeciality.Max();
            List<string> chart = new List<string> { " ", " ", " ", " " };
            for (int i = 0; i < maxStudents; i++)
            {
                for (int countChartItem = 0; countChartItem < chart.Count; countChartItem++)
                {
                    if (chart[0] == " ")
                    {
                        if (maxStudents - i == logic.countStudentsSpeciality[0])
                        {
                            chart[0] = "█";
                        }
                    }
                    if (chart[1] == " ")
                    {
                        if (maxStudents - i == logic.countStudentsSpeciality[1])
                        {
                            chart[1] = "█";
                        }
                    }
                    if (chart[2] == " ")
                    {
                        if (maxStudents - i == logic.countStudentsSpeciality[2])
                        {
                            chart[2] = "█";
                        }
                    }
                    if (chart[3] == " ")
                    {
                        if (maxStudents - i == logic.countStudentsSpeciality[3])
                        {
                            chart[3] = "█";
                        }
                    }
                }

                if (i <= maxStudents - 1 && maxStudents - i < 10)
                {
                    Console.WriteLine($"║ {maxStudents - i}   {chart[0]}    {chart[1]}    {chart[2]}    {chart[3]}    ║");
                }

                else if (i <= maxStudents - 1 && maxStudents - i >= 10)
                {
                    Console.WriteLine($"║ {maxStudents - i}  {chart[0]}    {chart[1]}    {chart[2]}    {chart[3]}    ║");
                }

                if (maxStudents - i == 1)
                {
                    Console.WriteLine($"║ 0 -------------------   ║");
                }
            }
            Console.WriteLine("║   ИСИТ   ИБ  ИВТ   ПИ   ║");
            Console.WriteLine("╚═════════════════════════╝");
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
