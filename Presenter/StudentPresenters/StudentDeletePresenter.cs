using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using WinFormsApp;
using Shared;
using Entities;
using Ninject;

namespace Presenter
{
    public class StudentDeletePresenter
    {
        private IManager<Student> manager;

        private IDeleteView view;

        /// <summary>
        /// Метод создания экземпляра StudentPresenter
        /// </summary>
        /// <param name="view">вьюшка</param>
        /// <param name="manager">логика модели</param>
        public StudentDeletePresenter(IDeleteView view, IManager<Student> manager)
        {
            this.manager = manager;
            this.view = view;

            //Добавляем методы в соответсвующие события
            manager.DataChanged += OnManagerDataChanged;

            view.DeleteDataEvent += manager.Delete;
        }

        /// <summary>
        /// Метод перерисовки вьюшки
        /// </summary>
        /// <param name="students">коллекция студентов</param>
        private void OnManagerDataChanged(IEnumerable<Student> students)
        {
            List<StudentEventArgs> args = new List<StudentEventArgs>();

            foreach(Student student in students)
            {
                args.Add(new StudentEventArgs()
                {
                    Name = student.Name,
                    Group = student.Group,
                    Speciality = student.Speciality,
                    Id = student.Id,
                });
            }
            view.RedrawForm(args);
        }

        /// <summary>
        /// Метод создания студента
        /// </summary>
        /// <param name="data">информация о новом студенте</param>
        private void OnAddData(EventArgs data)
        {
            StudentEventArgs args = data as StudentEventArgs;
            Student student = new Student();
            student.Name = args.Name;
            student.Group = args.Group;
            student.Speciality = args.Speciality;
            manager.Create(student);
        }

        /// <summary>
        /// Метод обновления студента
        /// </summary>
        /// <param name="data">новая информация о студенте</param>
        private void OnUpdateData(EventArgs data)
        {
            StudentEventArgs args = data as StudentEventArgs;
            Student student = new Student();
            student.Name = args.Name;
            student.Group = args.Group;
            student.Speciality = args.Speciality;
            student.Id = args.Id;
            manager.Update(student);
        }
    }
}
