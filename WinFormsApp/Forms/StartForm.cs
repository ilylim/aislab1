using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Shared;
using System.Linq;

namespace WinFormsApp
{
    public partial class StartForm : Form, IView, IDeleteView
    {
        private AddStudentForm addStudentForm { get; set; }
        private ChangeStudentForm changeStudentForm { get; set; }
        /// <summary>
        /// Метод перерисовки стартовой вьюшки
        /// </summary>
        /// <param name="students">коллекция всех студентов</param>
        public void RedrawForm(IEnumerable<EventArgs> students)
        {
            RefreshListView(students);
            RefreshChart(students);
        }
        
        public event Action<int> DeleteDataEvent;

        public StartForm(AddStudentForm addForm, ChangeStudentForm updateForm)
        {
            InitializeComponent();
            RemoveStudentButton.Enabled = false;
            ChangeStudentButton.Enabled = false;
            addStudentForm = addForm;
            addStudentForm.Owner = this;
            changeStudentForm = updateForm;
            changeStudentForm.Owner = this;
        }

        /// <summary>
        /// Метод для кнопки добавления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            addStudentForm.ShowDialog();
        }

        //public void AddStudent(StudentEventArgs addedStudent)
        //{
        //    AddDataEvent(addedStudent);
        //}

        //public void UpdateStudent(StudentEventArgs updatedStudent)
        //{
        //    UpdateDataEvent(updatedStudent);
        //}

        /// <summary>
        /// Метод для вывода содержимого базы данных в listView
        /// </summary>
        private void RefreshListView(IEnumerable<EventArgs> students)
        {
            listView.Items.Clear();
            foreach (StudentEventArgs student in students)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(student.Id));
                item.SubItems.Add(student.Name);
                item.SubItems.Add(student.Group);
                item.SubItems.Add(student.Speciality);
                listView.Items.Add(item);
            }
        }

        /// <summary>
        /// Метод для кнопки изменения студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeStudentButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                changeStudentForm.RefreshChangedItem();
                changeStudentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Для изменения студента необходимо его выбрать в списке");
            }
            RemoveStudentButton.Enabled = false;
            ChangeStudentButton.Enabled = false;
        }

        /// <summary>
        /// Метод для кнопки удаления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveStudentButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                DeleteDataEvent(Convert.ToInt32(((ListViewItem)(listView.SelectedItems[0])).SubItems[0].Text));
            }
            else
            {
                MessageBox.Show("Для удаления необходимо выбрать студента из списка");
            }
            RemoveStudentButton.Enabled = false;
            ChangeStudentButton.Enabled = false;
        }

        /// <summary>
        /// Метод взаимодействия со списком студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                //Включение кнопок удаления и изменения студентов
                RemoveStudentButton.Enabled = true;
                ChangeStudentButton.Enabled = true;
            }
        }

        /// <summary>
        /// Метод обновления гистограммы
        /// </summary>
        private void RefreshChart(IEnumerable<EventArgs> students)
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

            chart1.Series["Специальности"].Points.Clear();
            for (int i = 0; i < 4; i++)
            {
                chart1.Series["Специальности"].Points.AddXY(specialities[i], countStudentsSpeciality[i]);
            }
        }
    }
}
