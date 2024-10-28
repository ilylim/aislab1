namespace WinFormsApp
{
    partial class FormTest1\
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.RemoveStudentButton = new System.Windows.Forms.Button();
            this.ChangeStudentButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Location = new System.Drawing.Point(46, 12);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(175, 42);
            this.AddStudentButton.TabIndex = 1;
            this.AddStudentButton.Text = "Добавить нового студента";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // RemoveStudentButton
            // 
            this.RemoveStudentButton.Location = new System.Drawing.Point(46, 76);
            this.RemoveStudentButton.Name = "RemoveStudentButton";
            this.RemoveStudentButton.Size = new System.Drawing.Size(175, 38);
            this.RemoveStudentButton.TabIndex = 2;
            this.RemoveStudentButton.Text = "Удалить студента";
            this.RemoveStudentButton.UseVisualStyleBackColor = true;
            this.RemoveStudentButton.Click += new System.EventHandler(this.RemoveStudentButton_Click);
            // 
            // ChangeStudentButton
            // 
            this.ChangeStudentButton.Location = new System.Drawing.Point(46, 138);
            this.ChangeStudentButton.Name = "ChangeStudentButton";
            this.ChangeStudentButton.Size = new System.Drawing.Size(175, 38);
            this.ChangeStudentButton.TabIndex = 3;
            this.ChangeStudentButton.Text = "Изменить студента";
            this.ChangeStudentButton.UseVisualStyleBackColor = true;
            this.ChangeStudentButton.Click += new System.EventHandler(this.ChangeStudentButton_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(249, 12);
            this.listView.Margin = new System.Windows.Forms.Padding(2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(529, 164);
            this.listView.TabIndex = 13;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Click += new System.EventHandler(this.ListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ФИО";
            this.columnHeader2.Width = 207;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Группа";
            this.columnHeader3.Width = 175;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Специальность";
            this.columnHeader4.Width = 91;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(46, 195);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Специальности";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(732, 250);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            title4.Name = "Title1";
            title4.Text = "Разбиение студентов на специальности";
            this.chart1.Titles.Add(title4);
            // 
            // logicBindingSource
            // 
            this.logicBindingSource.DataSource = typeof(BusinessLogic.Logic);
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 457);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.ChangeStudentButton);
            this.Controls.Add(this.RemoveStudentButton);
            this.Controls.Add(this.AddStudentButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Button RemoveStudentButton;
        private System.Windows.Forms.Button ChangeStudentButton;
        private System.Windows.Forms.BindingSource logicBindingSource;
        internal System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.BindingSource studentsBindingSource;
    }
}

