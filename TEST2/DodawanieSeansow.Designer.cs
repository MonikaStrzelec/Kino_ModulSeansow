namespace Kino
{
    partial class DodawanieSeansow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.AppointmentMappingInfo appointmentMappingInfo1 = new Telerik.WinControls.UI.AppointmentMappingInfo();
            Telerik.WinControls.UI.ResourceMappingInfo resourceMappingInfo1 = new Telerik.WinControls.UI.ResourceMappingInfo();
            this.buttonAddPerformance = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.movieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.schedulerBindingDataSource1 = new Telerik.WinControls.UI.SchedulerBindingDataSource();
            this.button1 = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tytulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlugoscFilmu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godzinaZakonczeniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlugoscReklamMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainSeansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.czasRozpoczeciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasZakonczeniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainHoursOfPauseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1.EventProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1.ResourceProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainSeansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainHoursOfPauseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddPerformance
            // 
            this.buttonAddPerformance.Location = new System.Drawing.Point(302, 487);
            this.buttonAddPerformance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddPerformance.Name = "buttonAddPerformance";
            this.buttonAddPerformance.Size = new System.Drawing.Size(249, 99);
            this.buttonAddPerformance.TabIndex = 0;
            this.buttonAddPerformance.Text = "ADD PERFORMANCE";
            this.buttonAddPerformance.UseVisualStyleBackColor = true;
            this.buttonAddPerformance.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.movieBindingSource, "title", true));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hallBindingSource, "id", true));
            this.comboBox1.DataSource = this.movieBindingSource;
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(235, 39);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.none);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.none);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.none);
            this.comboBox1.Enter += new System.EventHandler(this.comboBox1_MouseEnter);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseEnter += new System.EventHandler(this.none);
            // 
            // movieBindingSource
            // 
            this.movieBindingSource.DataSource = typeof(Kino.Properties.Movie);
            // 
            // hallBindingSource
            // 
            this.hallBindingSource.DataSource = typeof(Kino.Properties.Hall);
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hallBindingSource, "name", true));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.movieBindingSource, "id", true));
            this.comboBox2.DataSource = this.hallBindingSource;
            this.comboBox2.DisplayMember = "name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(25, 382);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.ValueMember = "id";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.none);
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.none);
            this.comboBox2.Leave += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // schedulerBindingDataSource1
            // 
            // 
            // 
            // 
            this.schedulerBindingDataSource1.EventProvider.Mapping = appointmentMappingInfo1;
            // 
            // 
            // 
            this.schedulerBindingDataSource1.ResourceProvider.Mapping = resourceMappingInfo1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 487);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 99);
            this.button1.TabIndex = 7;
            this.button1.Text = "CLOSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(95, 125);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(220, 339);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select a title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select a room";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Time for advertising and cleaning:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a parameter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(11, 78);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(48, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "VR";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 49);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3D";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 21);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2D";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tytulDataGridViewTextBoxColumn,
            this.dlugoscFilmu,
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn,
            this.godzinaZakonczeniaDataGridViewTextBoxColumn,
            this.dlugoscReklamMinDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.domainSeansBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(445, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(683, 185);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tytulDataGridViewTextBoxColumn
            // 
            this.tytulDataGridViewTextBoxColumn.DataPropertyName = "tytul";
            this.tytulDataGridViewTextBoxColumn.HeaderText = "tytul";
            this.tytulDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tytulDataGridViewTextBoxColumn.Name = "tytulDataGridViewTextBoxColumn";
            this.tytulDataGridViewTextBoxColumn.Width = 125;
            // 
            // dlugoscFilmu
            // 
            this.dlugoscFilmu.DataPropertyName = "dlugoscFilmu";
            this.dlugoscFilmu.HeaderText = "dlugoscFilmu";
            this.dlugoscFilmu.MinimumWidth = 6;
            this.dlugoscFilmu.Name = "dlugoscFilmu";
            this.dlugoscFilmu.Width = 125;
            // 
            // godzinaRozpoczeciaDataGridViewTextBoxColumn
            // 
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn.DataPropertyName = "godzinaRozpoczecia";
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn.HeaderText = "godzinaRozpoczecia";
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn.Name = "godzinaRozpoczeciaDataGridViewTextBoxColumn";
            this.godzinaRozpoczeciaDataGridViewTextBoxColumn.Width = 125;
            // 
            // godzinaZakonczeniaDataGridViewTextBoxColumn
            // 
            this.godzinaZakonczeniaDataGridViewTextBoxColumn.DataPropertyName = "godzinaZakonczenia";
            this.godzinaZakonczeniaDataGridViewTextBoxColumn.HeaderText = "godzinaZakonczenia";
            this.godzinaZakonczeniaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.godzinaZakonczeniaDataGridViewTextBoxColumn.Name = "godzinaZakonczeniaDataGridViewTextBoxColumn";
            this.godzinaZakonczeniaDataGridViewTextBoxColumn.Width = 125;
            // 
            // dlugoscReklamMinDataGridViewTextBoxColumn
            // 
            this.dlugoscReklamMinDataGridViewTextBoxColumn.DataPropertyName = "dlugoscReklamMin";
            this.dlugoscReklamMinDataGridViewTextBoxColumn.HeaderText = "dlugoscReklamMin";
            this.dlugoscReklamMinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dlugoscReklamMinDataGridViewTextBoxColumn.Name = "dlugoscReklamMinDataGridViewTextBoxColumn";
            this.dlugoscReklamMinDataGridViewTextBoxColumn.Width = 125;
            // 
            // domainSeansBindingSource
            // 
            this.domainSeansBindingSource.DataSource = typeof(Kino.Domena.DomainSeans);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.czasRozpoczeciaDataGridViewTextBoxColumn,
            this.czasZakonczeniaDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.domainHoursOfPauseBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(445, 203);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(683, 202);
            this.dataGridView2.TabIndex = 17;
            // 
            // czasRozpoczeciaDataGridViewTextBoxColumn
            // 
            this.czasRozpoczeciaDataGridViewTextBoxColumn.DataPropertyName = "czasRozpoczecia";
            this.czasRozpoczeciaDataGridViewTextBoxColumn.HeaderText = "czasRozpoczecia";
            this.czasRozpoczeciaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.czasRozpoczeciaDataGridViewTextBoxColumn.Name = "czasRozpoczeciaDataGridViewTextBoxColumn";
            this.czasRozpoczeciaDataGridViewTextBoxColumn.Width = 125;
            // 
            // czasZakonczeniaDataGridViewTextBoxColumn
            // 
            this.czasZakonczeniaDataGridViewTextBoxColumn.DataPropertyName = "czasZakonczenia";
            this.czasZakonczeniaDataGridViewTextBoxColumn.HeaderText = "czasZakonczenia";
            this.czasZakonczeniaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.czasZakonczeniaDataGridViewTextBoxColumn.Name = "czasZakonczeniaDataGridViewTextBoxColumn";
            this.czasZakonczeniaDataGridViewTextBoxColumn.Width = 125;
            // 
            // domainHoursOfPauseBindingSource
            // 
            this.domainHoursOfPauseBindingSource.DataSource = typeof(Kino.Domena.DomainHoursOfPause);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(579, 487);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 99);
            this.button2.TabIndex = 18;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select a date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "label5";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 99);
            this.button3.TabIndex = 21;
            this.button3.Text = "EDIT TIME FOR CLEANING AND ADVERTISING";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sum of movie, cleaning, and ad time:";
            // 
            // DodawanieSeansow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 613);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonAddPerformance);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DodawanieSeansow";
            this.Text = "DodawanieSeansow";
            this.Load += new System.EventHandler(this.DodawanieSeansow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1.EventProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1.ResourceProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBindingDataSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainSeansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainHoursOfPauseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddPerformance;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource movieBindingSource;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource hallBindingSource;
        private Telerik.WinControls.UI.SchedulerBindingDataSource schedulerBindingDataSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource domainSeansBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn tytulDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlugoscFilmu;
        private System.Windows.Forms.DataGridViewTextBoxColumn godzinaRozpoczeciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn godzinaZakonczeniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlugoscReklamMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn czasRozpoczeciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn czasZakonczeniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource domainHoursOfPauseBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}