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
    public class StudentPresenter
    {
        private IManager<Student> manager;

        private ViewArgs views;
        private IView redrawedView;

        /// <summary>
        /// Метод создания экземпляра StudentPresenter
        /// </summary>
        /// <param name="view">вьюшка</param>
        /// <param name="manager">логика модели</param>
        public StudentPresenter(ViewArgs views, IManager<Student> manager)
        {
            this.manager = manager;
            this.views = views;
            redrawedView = views.deleteView;

            //Добавляем методы в соответсвующие события
            manager.DataChanged += OnManagerDataChanged;
            manager.ReadAll(); //Вызываем в самом начале для загрузки информации о сущностях во вьюшку

            views.addView.AddDataEvent += OnAddData;
            views.deleteView.DeleteDataEvent += manager.Delete;
            views.updateView.UpdateDataEvent += OnUpdateData;
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
            redrawedView.RedrawForm(args);
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
            redrawedView = views.addView;
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
            redrawedView = views.updateView;
            manager.Update(student);
        }
    }
}
