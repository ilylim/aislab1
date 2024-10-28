using Model;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.Dapper;

namespace BusinessLogic
{
    public class Logic
    {
        IRepository<Student> repository = new EntityRepository<Student>();
        //IRepository<Student> repository = new DapperRepository<Student>();
        public Dictionary<int, Student> Students { set; get; } = new Dictionary<int, Student>(); //Словарь со студентами (id, student)
        public List<string> specialities = new List<string>() { "ИСИТ", "ИБ", "ИВТ", "ПИ" }; //Коллекция специальностей
        public List<int> countStudentsSpeciality = new List<int>() { 0, 0, 0, 0 }; //Коллекция количества студентов на специальностях

        /// <summary>
        /// Метод добавления студентов
        /// </summary>
        /// <param name="name">ФИО студента</param>
        /// <param name="group">группа</param>
        /// <param name="speciality">специальность</param>
        public void AddStudent(string name, string group, string speciality)
        {
            Student student = new Student()
            {
                Name = name,
                Group = group,
                Speciality = speciality
            };
            repository.Create(student);
            Students.Add(student.Id, student);
        }

        /// <summary>
        /// Метод создания списка с данными о студентах
        /// </summary>
        /// <returns>список с кортежами с информацией (id, name, group, speciality) студентов</returns>
        public List<(int, string, string, string)> GetAllStudents()
        {
            List<(int, string, string, string)> students = new List<(int, string, string, string)>();
            foreach(var student in Students.Values)
            {
                students.Add((student.Id, student.Name, student.Group, student.Speciality));
            }
            return students;
        }

        /// <summary>
        /// Метод добавления информации из БД в словарь студентов
        /// </summary>
        public void GetAllDictionary()
        {
            List<Student> allStudents = repository.GetAll().ToList();
            Students.Clear();
            foreach(Student student in allStudents)
            {
                Students.Add((int)student.Id, student);
            }
        }

        /// <summary>
        /// Метод поиска свободного id 
        /// </summary>
        /// <returns>id последнего добавленного студента + 1</returns>
        public int GetLastId()
        {
            if(Students.Count() != 0)
            {
                return Students.Last().Key;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Метод удаления студентов
        /// </summary>
        /// <param name="code">код студента</param>
        public void RemoveStudent(int code)
        {
            repository.Delete(Students[code]);
            Students.Remove(code);
        }

        /// <summary>
        /// Метод изменения студента
        /// </summary>
        /// <param name="code">код студента</param>
        /// <param name="newName">измененное ФИО</param>
        /// <param name="newGroup">измененная группа</param>
        /// <param name="newSpeciality">измененная специальность</param>
        public void ChangeStudent(int code, string newName, string newGroup, string newSpeciality)
        {
            Student student = Students[code];
            if (newName != "")
            {
                student.Name = newName;
            }
            if (newGroup != "")
            {
                student.Group = newGroup;
            }
            if (newSpeciality != "")
            {
                student.Speciality = newSpeciality;
            }
            repository.Update(Students[code]);
        }

        /// <summary>
        /// Метод вывода количества студентов по специальностям
        /// </summary>
        public void GetStudentsSpecialities()
        {
            for (int countSpeciality = 0; countSpeciality <= specialities.Count() - 1; countSpeciality++)
            {
                countStudentsSpeciality[countSpeciality] = 0;
                foreach (Student student in Students.Values)
                {
                    if (student.Speciality == specialities[countSpeciality])
                    {
                        countStudentsSpeciality[countSpeciality]++;
                    }
                }
            }
        }
    }
}
