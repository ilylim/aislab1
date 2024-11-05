using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RemoveStudentButton.Enabled = false;
            ChangeStudentButton.Enabled = false;
            RefreshListView();
        }

        /// <summary>
        /// Метод для кнопки добавления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            Form2 addStudentForm = new Form2();
            addStudentForm.Owner = this;
            addStudentForm.ShowDialog();
        }

        /// <summary>
        /// Метод для вывода содержимого базы данных в listView
        /// </summary>
        public void RefreshListView()
        {
            listView.Items.Clear();
            foreach (var itemData in LogicDTO.studentsManager.GetAllStudents())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(itemData.Item1));
                item.SubItems.Add(itemData.Item2);
                item.SubItems.Add(itemData.Item3);
                item.SubItems.Add(itemData.Item4);
                listView.Items.Add(item);
            }
            RefreshChart();
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
                Form3 changeStudentForm = new Form3((ListViewItem)listView.SelectedItems[0]);
                changeStudentForm.Owner = this;
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
                LogicDTO.studentsManager.Delete(Convert.ToInt32(((ListViewItem)(listView.SelectedItems[0])).SubItems[0].Text));
                RefreshListView();
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
        internal void RefreshChart()
        {
            chart1.Series["Специальности"].Points.Clear();
            LogicDTO.studentsManager.GetStudentsSpecialities();
            for (int i = 0; i < 4; i++)
            {
                chart1.Series["Специальности"].Points.AddXY(LogicDTO.studentsManager.specialities[i], LogicDTO.studentsManager.countStudentsSpeciality[i]);
            }
        }
    }
}
