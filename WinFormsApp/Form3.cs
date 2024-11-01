﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace WinFormsApp
{
    public partial class Form3 : Form
    {
        int idChangedStudent = 0;

        public Form3(ListViewItem changedItem)
        {
            InitializeComponent();
            Form1 main = this.Owner as Form1;

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
            Form1 main = this.Owner as Form1;
            LogicDTO.Logic.ChangeStudent(idChangedStudent,
                textBox1.Text, textBox2.Text, comboBox1.Text);

            main.RefreshListView();

            this.Close();
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
