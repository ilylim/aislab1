using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Shared;
using System.Threading.Tasks;

namespace aislab1
{
    public class ConsoleView : IConsoleView, ITransitionView
    {
        public event Action ChangeView;
        public event Action<EventArgs> AddDataEvent;
        public event Action<int> DeleteDataEvent;
        public event Action<EventArgs> UpdateDataEvent;
        private IEnumerable<EventArgs> students;

        /// <summary>
        /// Метод подгрузки информации о студентах
        /// </summary>
        /// <param name="args"></param>
        public void RedrawForm(IEnumerable<EventArgs> args)
        {
            students = args;
        }

        /// <summary>
        /// Метод реализации лабы через меню в консоли
        /// </summary>
        private void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить студента\n2. Удалить студента\n3. Изменить студента\n4. Показать таблицу\n5. Показать гистограмму студентов по специальностям\n6. Перейти в винформы\n7. Выход");
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
                                        Console.WriteLine($"ФИО студента: {name}\nГруппа студента: {group}\n\nВыберите специализацию студента\n1 - ИСИТ\n2 - ИБ\n3 - ИВТ\n4 - ПИ");
                                        if (Int32.TryParse(Console.ReadLine(), out int codeSpeciality) && codeSpeciality > 0 && codeSpeciality < 5)
                                        {
                                            switch (codeSpeciality)
                                            {
                                                case 1:
                                                    AddStudent(name, group, "ИСИТ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 2:
                                                    AddStudent(name, group, "ИБ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 3:
                                                    AddStudent(name, group, "ИВТ");
                                                    correctSpeciality = true;
                                                    break;
                                                case 4:
                                                    AddStudent(name, group, "ПИ");
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
                            PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Введите код студента из списка");
                            if (Int32.TryParse(Console.ReadLine(), out int codeRemovedStudent) && codeRemovedStudent > 0)
                            {
                                if (!(FindStudent(codeRemovedStudent)))
                                {
                                    Console.WriteLine("Студента с таким кодом не существует !");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    DeleteDataEvent(codeRemovedStudent);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Код студента является числом > 0");
                                Console.ReadKey();
                            }
                            break;

                        case 3:
                            Console.Clear();
                            PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Введите код студента из списка");
                            if (Int32.TryParse(Console.ReadLine(), out int codeChangedStudent) && codeChangedStudent > 0)
                            {
                                if (!(FindStudent(codeChangedStudent)))
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

                                                    Console.WriteLine($"ФИО студента {codeChangedStudent} изменено на {studentNewName}\n");
                                                    UpdateStudent(codeChangedStudent, studentNewName, "", "");
                                                    break;

                                                case 2:
                                                    Console.WriteLine("Введите новую группу студента");
                                                    string studentNewGroup = Console.ReadLine();

                                                    Console.WriteLine($"Группа студента {codeChangedStudent} изменена на {studentNewGroup}\n");
                                                    UpdateStudent(codeChangedStudent, "", studentNewGroup, "");
                                                    break;

                                                case 3:
                                                    Console.WriteLine("Введите новую специальность студента\n1 - ИСИТ\n2 - ИБ\n3 - ИВТ\n4 - ПИ\n");
                                                    bool correctNewSpeciality = false;
                                                    while (!correctNewSpeciality)
                                                    {
                                                        if (Int32.TryParse(Console.ReadLine(), out int codeNewSpeciality) && codeNewSpeciality > 0 && codeNewSpeciality < 5)
                                                        {
                                                            switch (codeNewSpeciality)
                                                            {
                                                                case 1:
                                                                    UpdateStudent(codeChangedStudent, "", "", "ИСИТ");
                                                                    Console.WriteLine($"Специальность студента {codeChangedStudent} изменена на ИСИТ\n");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 2:
                                                                    UpdateStudent(codeChangedStudent, "", "", "ИБ");
                                                                    Console.WriteLine($"Специальность студента {codeChangedStudent} изменена на ИБ\n");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 3:
                                                                    UpdateStudent(codeChangedStudent, "", "", "ИВТ");
                                                                    Console.WriteLine($"Специальность студента {codeChangedStudent} изменена на ИВТ\n");
                                                                    correctNewSpeciality = true;
                                                                    break;
                                                                case 4:
                                                                    UpdateStudent(codeChangedStudent, "", "", "ПИ");
                                                                    Console.WriteLine($"Специальность студента {codeChangedStudent} изменена на ПИ\n");
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
                                            Console.WriteLine("Выберите число от 1 до 4 ! ! !");
                                        }
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
                            PrintList();
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            PrintChart();
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            ChangeView();
                            exit = true;
                            break;

                        case 7:
                            exit = true;
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Введите число от 1 до 7 !");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Метод обновления студента
        /// </summary>
        /// <param name="id">id обновляемого студента</param>
        /// <param name="newName">новое ФИО</param>
        /// <param name="newGroup">новая группа</param>
        /// <param name="newSpeciality">новая специальность</param>
        private void UpdateStudent(int id, string newName, string newGroup, string newSpeciality)
        {
            StudentEventArgs updatedStudent = new StudentEventArgs();
            foreach(StudentEventArgs student in students)
            {
                if(student.Id == id)
                {
                    updatedStudent.Name = student.Name;
                    updatedStudent.Group = student.Group;
                    updatedStudent.Speciality = student.Speciality;
                    updatedStudent.Id = student.Id;
                }
            }

            if (!(string.IsNullOrEmpty(newName) || string.IsNullOrWhiteSpace(newName)))
            {
                updatedStudent.Name = newName;
            }
            if (!(string.IsNullOrEmpty(newGroup) || string.IsNullOrWhiteSpace(newGroup)))
            {
                updatedStudent.Group = newGroup;
            }
            if(!(string.IsNullOrEmpty(newSpeciality) || string.IsNullOrWhiteSpace(newSpeciality)))
            {
                updatedStudent.Speciality = newSpeciality;
            }

            UpdateDataEvent(updatedStudent);
        }

        /// <summary>
        /// Метод добавления студента
        /// </summary>
        /// <param name="name">ФИО студента</param>
        /// <param name="group">группа</param>
        /// <param name="speciality">специальность</param>
        private void AddStudent(string name, string group, string speciality)
        {
            StudentEventArgs newStudent = new StudentEventArgs()
            {
                Name = name,
                Group = group,
                Speciality = speciality
            };

            AddDataEvent(newStudent);
        }

        /// <summary>
        /// Проверка наличия студента в БДшке по его id
        /// </summary>
        /// <param name="id">id студента</param>
        /// <returns>найден студент или нет</returns>
        private bool FindStudent(int id)
        {
            foreach (StudentEventArgs student in students)
            {
                if (student.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод вывода таблицы в консоль
        /// </summary>
        private void PrintList()
        {
            Console.Clear();
            List<(int, string, string, string)> studentsInfo = new List<(int, string, string, string)>();
            foreach (StudentEventArgs student in students)
            {
                studentsInfo.Add((student.Id, student.Name, student.Group, student.Speciality));
            }
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
        private void PrintChart()
        {
            List<string> specialities = new List<string>() { "ИСИТ", "ИБ", "ИВТ", "ПИ" };
            List<int> countStudentsSpeciality = new List<int>() { 0, 0, 0, 0 }; //Коллекция количества студентов на специальностях

            for (int countSpeciality = 0; countSpeciality <= specialities.Count() - 1; countSpeciality++)
            {
                countStudentsSpeciality[countSpeciality] = 0;
                foreach (StudentEventArgs student in students)
                {
                    if (student.Speciality == specialities[countSpeciality])
                    {
                        countStudentsSpeciality[countSpeciality]++;
                    }
                }
            }
            Console.WriteLine("╔═════════════════════════╗");
            int maxStudents = countStudentsSpeciality.Max();
            List<string> chart = new List<string> { " ", " ", " ", " " };
            for (int i = 0; i < maxStudents; i++)
            {
                for (int countChartItem = 0; countChartItem < chart.Count; countChartItem++)
                {
                    if (chart[0] == " ")
                    {
                        if (maxStudents - i == countStudentsSpeciality[0])
                        {
                            chart[0] = "█";
                        }
                    }
                    if (chart[1] == " ")
                    {
                        if (maxStudents - i == countStudentsSpeciality[1])
                        {
                            chart[1] = "█";
                        }
                    }
                    if (chart[2] == " ")
                    {
                        if (maxStudents - i == countStudentsSpeciality[2])
                        {
                            chart[2] = "█";
                        }
                    }
                    if (chart[3] == " ")
                    {
                        if (maxStudents - i == countStudentsSpeciality[3])
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

        public void Main()
        {
            Menu();
        }
    }
}
