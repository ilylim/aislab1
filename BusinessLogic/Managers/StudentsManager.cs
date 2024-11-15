using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.Dapper;
using System;
using Entities;
using Ninject;

namespace BusinessLogic
{
    public class StudentsManager : IManager<Student>
    {
        private IRepository<Student> Repository { get; set; } = new DapperRepository<Student>(); 

        /// <summary>
        /// Событие оповещения об изменении сущностей
        /// </summary>
        public event Action<IEnumerable<Student>> DataChanged;

        private Dictionary<int, Student> Students = new Dictionary<int, Student>(); //Словарь со студентами (id, student)
        public List<string> specialities = new List<string>() { "ИСИТ", "ИБ", "ИВТ", "ПИ" }; //Коллекция специальностей
        public List<int> countStudentsSpeciality = new List<int>() { 0, 0, 0, 0 }; //Коллекция количества студентов на специальностях

        /// <summary>
        /// Метод добавления студентов
        /// </summary>
        /// <param name="name">ФИО студента</param>
        /// <param name="group">группа</param>
        /// <param name="speciality">специальность</param>
        public void Create(Student newStudent)
        {
            Repository.Create(newStudent);
            Students.Add(newStudent.Id, newStudent);
            InvokeDataChanged();
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
            InvokeDataChanged();
        }

        /// <summary>
        /// Метод удаления студентов
        /// </summary>
        /// <param name="code">код студента</param>
        public void Delete(int code)
        {
            Repository.Delete(Students[code]);
            Students.Remove(code);
            InvokeDataChanged();
        }

        /// <summary>
        /// Метод изменения студента
        /// </summary>
        /// <param name="code">код студента</param>
        /// <param name="newName">измененное ФИО</param>
        /// <param name="newGroup">измененная группа</param>
        /// <param name="newSpeciality">измененная специальность</param>
        public void Update(Student updateStudent)
        {
            Students[updateStudent.Id] = updateStudent;
            Repository.Update(updateStudent);
            InvokeDataChanged();
        }

        /// <summary>
        /// Вызов события DataChanged
        /// </summary>
        private void InvokeDataChanged()
        {
            DataChanged?.Invoke(Students.Values);
        }
    }
}
