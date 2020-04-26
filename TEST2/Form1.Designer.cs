namespace TEST2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timetableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entityConnection1 = new System.Data.Entity.Core.EntityClient.EntityConnection();
            this.kinoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.performance1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timetableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adsDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hall1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movie1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timetablesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.performanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(389, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "WYŚWIETL LISTĘ SEANSÓW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewImageColumn1,
            this.performance1DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.timetableBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(18, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(423, 600);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(489, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 671);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.movieDataGridViewTextBoxColumn,
            this.hallDataGridViewTextBoxColumn,
            this.adsDurationDataGridViewTextBoxColumn,
            this.hall1DataGridViewTextBoxColumn,
            this.movie1DataGridViewTextBoxColumn,
            this.timetablesDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.performanceBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(11, 417);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(463, 239);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 394);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTRUJ SEANSE";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 34);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(235, 106);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ZAKRES DAT";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 185);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "ZASTOSUJ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(6, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 671);
            this.panel2.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "performance";
            this.dataGridViewTextBoxColumn3.HeaderText = "performance";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "performanceDate";
            this.dataGridViewImageColumn1.HeaderText = "performanceDate";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // performance1DataGridViewTextBoxColumn
            // 
            this.performance1DataGridViewTextBoxColumn.DataPropertyName = "Performance1";
            this.performance1DataGridViewTextBoxColumn.HeaderText = "Performance1";
            this.performance1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.performance1DataGridViewTextBoxColumn.Name = "performance1DataGridViewTextBoxColumn";
            this.performance1DataGridViewTextBoxColumn.Width = 125;
            // 
            // timetableBindingSource2
            // 
            this.timetableBindingSource2.DataSource = typeof(TEST2.Timetable);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn2.HeaderText = "id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // movieDataGridViewTextBoxColumn
            // 
            this.movieDataGridViewTextBoxColumn.DataPropertyName = "movie";
            this.movieDataGridViewTextBoxColumn.HeaderText = "movie";
            this.movieDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.movieDataGridViewTextBoxColumn.Name = "movieDataGridViewTextBoxColumn";
            this.movieDataGridViewTextBoxColumn.Width = 125;
            // 
            // hallDataGridViewTextBoxColumn
            // 
            this.hallDataGridViewTextBoxColumn.DataPropertyName = "hall";
            this.hallDataGridViewTextBoxColumn.HeaderText = "hall";
            this.hallDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hallDataGridViewTextBoxColumn.Name = "hallDataGridViewTextBoxColumn";
            this.hallDataGridViewTextBoxColumn.Width = 125;
            // 
            // adsDurationDataGridViewTextBoxColumn
            // 
            this.adsDurationDataGridViewTextBoxColumn.DataPropertyName = "adsDuration";
            this.adsDurationDataGridViewTextBoxColumn.HeaderText = "adsDuration";
            this.adsDurationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adsDurationDataGridViewTextBoxColumn.Name = "adsDurationDataGridViewTextBoxColumn";
            this.adsDurationDataGridViewTextBoxColumn.Width = 125;
            // 
            // hall1DataGridViewTextBoxColumn
            // 
            this.hall1DataGridViewTextBoxColumn.DataPropertyName = "Hall1";
            this.hall1DataGridViewTextBoxColumn.HeaderText = "Hall1";
            this.hall1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hall1DataGridViewTextBoxColumn.Name = "hall1DataGridViewTextBoxColumn";
            this.hall1DataGridViewTextBoxColumn.Width = 125;
            // 
            // movie1DataGridViewTextBoxColumn
            // 
            this.movie1DataGridViewTextBoxColumn.DataPropertyName = "Movie1";
            this.movie1DataGridViewTextBoxColumn.HeaderText = "Movie1";
            this.movie1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.movie1DataGridViewTextBoxColumn.Name = "movie1DataGridViewTextBoxColumn";
            this.movie1DataGridViewTextBoxColumn.Width = 125;
            // 
            // timetablesDataGridViewTextBoxColumn
            // 
            this.timetablesDataGridViewTextBoxColumn.DataPropertyName = "Timetables";
            this.timetablesDataGridViewTextBoxColumn.HeaderText = "Timetables";
            this.timetablesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timetablesDataGridViewTextBoxColumn.Name = "timetablesDataGridViewTextBoxColumn";
            this.timetablesDataGridViewTextBoxColumn.Width = 125;
            // 
            // performanceBindingSource1
            // 
            this.performanceBindingSource1.DataSource = typeof(TEST2.Performance);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(TEST2.User);
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataSource = typeof(TEST2.User);
            // 
            // userBindingSource2
            // 
            this.userBindingSource2.DataSource = typeof(TEST2.User);
            // 
            // performanceBindingSource
            // 
            this.performanceBindingSource.DataSource = typeof(TEST2.Performance);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 715);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;

        private System.Windows.Forms.BindingSource timetableBindingSource;

        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn performanceDateDataGridViewImageColumn;
        private System.Windows.Forms.BindingSource kinoDataSetBindingSource;
        private System.Data.Entity.Core.EntityClient.EntityConnection entityConnection1;

        private System.Windows.Forms.BindingSource timetableBindingSource1;
  
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn performanceDateDataGridViewImageColumn1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource2;
        private System.Windows.Forms.BindingSource performanceBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hallDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adsDurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hall1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movie1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timetablesDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource performanceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn performance1DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource timetableBindingSource2;
    }
}

