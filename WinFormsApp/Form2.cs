﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AddButton.Enabled = false;
        }

        /// <summary>
        /// Метод для кнопки добавления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrWhiteSpace(textBox1.Text)) &&
                !(string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text)) &&
                 !(string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrWhiteSpace(comboBox1.Text))) //проверка на дурака
            {
                LogicDTO.Logic.AddStudent(textBox1.Text, textBox2.Text, comboBox1.Text);

                Form1 main = this.Owner as Form1;
                main.RefreshListView();

                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели не все данные");
            }
        }

        /// <summary>
        /// Метод включения/отключения кнопок при заполненном ФИО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && comboBox1.Text.Length > 0)
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
            }
        }

        /// <summary>
        /// Метод включения/отключения кнопок при заполненной группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && comboBox1.Text.Length > 0)
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
            }
        }

        /// <summary>
        /// Метод включения/отключения кнопок при заполненной специальности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && comboBox1.Text.Length > 0)
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
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
