namespace PersonnelMenagement
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
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskName_textBox = new System.Windows.Forms.TextBox();
            this.TaskDescription_textBox = new System.Windows.Forms.TextBox();
            this.TaskSaveBtn = new System.Windows.Forms.Button();
            this.addUser_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "\"dd/MM/yyyy\"";
            this.dateTimePicker1.Location = new System.Drawing.Point(52, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2020, 4, 9, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(77, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dodaj zadanie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nazwa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Opis";
            // 
            // TaskName_textBox
            // 
            this.TaskName_textBox.Location = new System.Drawing.Point(15, 84);
            this.TaskName_textBox.Name = "TaskName_textBox";
            this.TaskName_textBox.Size = new System.Drawing.Size(219, 20);
            this.TaskName_textBox.TabIndex = 5;
            // 
            // TaskDescription_textBox
            // 
            this.TaskDescription_textBox.Location = new System.Drawing.Point(15, 123);
            this.TaskDescription_textBox.Name = "TaskDescription_textBox";
            this.TaskDescription_textBox.Size = new System.Drawing.Size(219, 20);
            this.TaskDescription_textBox.TabIndex = 6;
            // 
            // TaskSaveBtn
            // 
            this.TaskSaveBtn.Location = new System.Drawing.Point(12, 150);
            this.TaskSaveBtn.Name = "TaskSaveBtn";
            this.TaskSaveBtn.Size = new System.Drawing.Size(222, 23);
            this.TaskSaveBtn.TabIndex = 7;
            this.TaskSaveBtn.Text = "Zapisz";
            this.TaskSaveBtn.UseVisualStyleBackColor = true;
            this.TaskSaveBtn.Click += new System.EventHandler(this.TaskSaveBtn_Click);
            // 
            // addUser_button
            // 
            this.addUser_button.Location = new System.Drawing.Point(297, 9);
            this.addUser_button.Name = "addUser_button";
            this.addUser_button.Size = new System.Drawing.Size(222, 23);
            this.addUser_button.TabIndex = 8;
            this.addUser_button.Text = "Dodaj użytkownika";
            this.addUser_button.UseVisualStyleBackColor = true;
            this.addUser_button.Click += new System.EventHandler(this.addUser_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 537);
            this.Controls.Add(this.addUser_button);
            this.Controls.Add(this.TaskSaveBtn);
            this.Controls.Add(this.TaskDescription_textBox);
            this.Controls.Add(this.TaskName_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TaskName_textBox;
        private System.Windows.Forms.TextBox TaskDescription_textBox;
        private System.Windows.Forms.Button TaskSaveBtn;
        private System.Windows.Forms.Button addUser_button;
    }
}

