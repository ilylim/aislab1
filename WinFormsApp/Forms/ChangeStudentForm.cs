using Shared;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace WinFormsApp
{
    public partial class ChangeStudentForm : Form, IUpdateView
    {
        public event Action<EventArgs> UpdateDataEvent;

        int idChangedStudent = 0;

        public StartForm main { get; set; }
        private ListViewItem changedItem { get; set; }

        public ChangeStudentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод смены изменяющегося студента
        /// </summary>
        public void RefreshChangedItem()
        {
            changedItem = main.listView.SelectedItems[0];
            textBox1.Text = changedItem.SubItems[1].Text;
            textBox2.Text = changedItem.SubItems[2].Text;
            comboBox1.Text = changedItem.SubItems[3].Text;
            this.idChangedStudent = Convert.ToInt32(changedItem.SubItems[0].Text);
        }
       
        /// <summary>
        /// Метод для кнопки изменения студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            StartForm main = this.Owner as StartForm;
            StudentEventArgs updatedStudent = new StudentEventArgs()
            {
                Name = textBox1.Text,
                Group = textBox2.Text,
                Speciality = comboBox1.Text,
                Id = idChangedStudent,
            };

            UpdateDataEvent(updatedStudent);

            this.Close();
        }

        /// <summary>
        /// Метод обновления вьюшки
        /// </summary>
        /// <param name="args">список с информацией о студентах</param>
        public void RedrawForm(IEnumerable<EventArgs> args)
        {
            main.RedrawForm(args);
        }

        /// <summary>
        /// Метод включения/отключения кнопок при заполненном ФИО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        /// <summary>
        /// Метод включения/отключения кнопок при заполненной группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        /// <summary>
        /// Метод блокировки ввода ФИО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

    }
}
