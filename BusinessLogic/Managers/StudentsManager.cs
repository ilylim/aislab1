using Model;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.Dapper;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public class StudentsManager : IManager<StudentData>
    {   
        private IRepository<Student> Repository { get; set; }

        public StudentsManager(IRepository<Student> repository)
        {
            Repository = repository;
            ReadAll();
        }

        private Dictionary<int, Student> Students { set; get; } = new Dictionary<int, Student>(); //Словарь со студентами (id, student)
        public List<string> specialities = new List<string>() { "ИСИТ", "ИБ", "ИВТ", "ПИ" }; //Коллекция специальностей
        public List<int> countStudentsSpeciality = new List<int>() { 0, 0, 0, 0 }; //Коллекция количества студентов на специальностях

        /// <summary>
        /// Метод добавления студентов
        /// </summary>
        /// <param name="name">ФИО студента</param>
        /// <param name="group">группа</param>
        /// <param name="speciality">специальность</param>
        public void Create(StudentData newStudent)
        {
            Student student = new Student()
            {
                Name = newStudent.Name,
                Group = newStudent.Group,
                Speciality = newStudent.Speciality
            };
            Repository.Create(student);
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
        public void ReadAll()
        {
            List<Student> allStudents = Repository.GetAll().ToList();
            Students.Clear();
            foreach(Student student in allStudents)
            {
                Students.Add(student.Id, student);
            }
        }

        /// <summary>
        /// Метод удаления студентов
        /// </summary>
        /// <param name="code">код студента</param>
        public void Delete(int code)
        {
            Repository.Delete(Students[code]);
            Students.Remove(code);
        }

        /// <summary>
        /// Метод изменения студента
        /// </summary>
        /// <param name="code">код студента</param>
        /// <param name="newName">измененное ФИО</param>
        /// <param name="newGroup">измененная группа</param>
        /// <param name="newSpeciality">измененная специальность</param>
        public void Update(int id, StudentData updateStudent)
        {
            Student student = Students[id];
            if (updateStudent.Name != "")
            {
                student.Name = updateStudent.Name;
            }
            if (updateStudent.Group != "")
            {
                student.Group = updateStudent.Group;
            }
            if (updateStudent.Speciality != "")
            {
                student.Speciality = updateStudent.Speciality;
            }
            Repository.Update(Students[id]);
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
