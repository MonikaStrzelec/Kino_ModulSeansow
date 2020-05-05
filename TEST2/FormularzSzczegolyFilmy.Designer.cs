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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
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
            this.timetableDomainClassBindingSource.DataSource = typeof(Kino.TimetableDomainClass);
            // 
            // timetableBindingSource
            // 
            this.timetableBindingSource.DataSource = typeof(Kino.Properties.Timetable);
            // 
            // FormularzSzczegolyFilmy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 450);
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
    }
}