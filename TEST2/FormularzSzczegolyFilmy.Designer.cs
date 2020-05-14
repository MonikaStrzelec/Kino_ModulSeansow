namespace Kino
{
    partial class FormularzSzczegolyFilmy
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timetableDomainClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableDomainClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.movieTypeDataGridViewTextBoxColumn,
            this.dataTimeDataGridViewTextBoxColumn,
            this.hallNameDataGridViewTextBoxColumn,
            this.hallTypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.timetableDomainClassBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(44, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(830, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // movieTypeDataGridViewTextBoxColumn
            // 
            this.movieTypeDataGridViewTextBoxColumn.DataPropertyName = "movieType";
            this.movieTypeDataGridViewTextBoxColumn.HeaderText = "movieType";
            this.movieTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.movieTypeDataGridViewTextBoxColumn.Name = "movieTypeDataGridViewTextBoxColumn";
            this.movieTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataTimeDataGridViewTextBoxColumn
            // 
            this.dataTimeDataGridViewTextBoxColumn.DataPropertyName = "dataTime";
            this.dataTimeDataGridViewTextBoxColumn.HeaderText = "dataTime";
            this.dataTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataTimeDataGridViewTextBoxColumn.Name = "dataTimeDataGridViewTextBoxColumn";
            this.dataTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // hallNameDataGridViewTextBoxColumn
            // 
            this.hallNameDataGridViewTextBoxColumn.DataPropertyName = "hallName";
            this.hallNameDataGridViewTextBoxColumn.HeaderText = "hallName";
            this.hallNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hallNameDataGridViewTextBoxColumn.Name = "hallNameDataGridViewTextBoxColumn";
            this.hallNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // hallTypeDataGridViewTextBoxColumn
            // 
            this.hallTypeDataGridViewTextBoxColumn.DataPropertyName = "hallType";
            this.hallTypeDataGridViewTextBoxColumn.HeaderText = "hallType";
            this.hallTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hallTypeDataGridViewTextBoxColumn.Name = "hallTypeDataGridViewTextBoxColumn";
            this.hallTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // timetableDomainClassBindingSource
            // 
            this.timetableDomainClassBindingSource.DataSource = typeof(Kino.Domena.TimetableDomain);
            // 
            // timetableBindingSource
            // 
            this.timetableBindingSource.DataSource = typeof(Kino.Properties.Timetable);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Performance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 71);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(619, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(241, 71);
            this.button3.TabIndex = 3;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormularzSzczegolyFilmy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 342);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormularzSzczegolyFilmy";
            this.Text = "FormularzSzczegolyFilmy";
            this.Load += new System.EventHandler(this.FormularzSzczegolyFilmy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableDomainClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource timetableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hallNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hallTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource timetableDomainClassBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}