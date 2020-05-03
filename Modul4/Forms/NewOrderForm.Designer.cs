namespace Modul4
{
    partial class NewOrderForm
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
            this.packGrid = new System.Windows.Forms.DataGridView();
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.infoGrid = new System.Windows.Forms.DataGridView();
            this.backBtn = new System.Windows.Forms.Button();
            this.cancelOrderBtn = new System.Windows.Forms.Button();
            this.confirmOrderBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.packGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // packGrid
            // 
            this.packGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packGrid.Location = new System.Drawing.Point(12, 42);
            this.packGrid.Name = "packGrid";
            this.packGrid.Size = new System.Drawing.Size(329, 355);
            this.packGrid.TabIndex = 0;
            // 
            // orderGrid
            // 
            this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGrid.Location = new System.Drawing.Point(459, 42);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.Size = new System.Drawing.Size(329, 355);
            this.orderGrid.TabIndex = 1;
            // 
            // infoGrid
            // 
            this.infoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoGrid.Location = new System.Drawing.Point(13, 457);
            this.infoGrid.Name = "infoGrid";
            this.infoGrid.Size = new System.Drawing.Size(328, 150);
            this.infoGrid.TabIndex = 2;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(13, 13);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Go back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // cancelOrderBtn
            // 
            this.cancelOrderBtn.Location = new System.Drawing.Point(497, 561);
            this.cancelOrderBtn.Name = "cancelOrderBtn";
            this.cancelOrderBtn.Size = new System.Drawing.Size(100, 23);
            this.cancelOrderBtn.TabIndex = 4;
            this.cancelOrderBtn.Text = "Cancel order";
            this.cancelOrderBtn.UseVisualStyleBackColor = true;
            // 
            // confirmOrderBtn
            // 
            this.confirmOrderBtn.Location = new System.Drawing.Point(625, 561);
            this.confirmOrderBtn.Name = "confirmOrderBtn";
            this.confirmOrderBtn.Size = new System.Drawing.Size(135, 23);
            this.confirmOrderBtn.TabIndex = 5;
            this.confirmOrderBtn.Text = "Confirm order";
            this.confirmOrderBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(360, 132);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = ">>>";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // undoBtn
            // 
            this.undoBtn.Location = new System.Drawing.Point(360, 204);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 23);
            this.undoBtn.TabIndex = 7;
            this.undoBtn.Text = "<<<";
            this.undoBtn.UseVisualStyleBackColor = true;
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 619);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.confirmOrderBtn);
            this.Controls.Add(this.cancelOrderBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.infoGrid);
            this.Controls.Add(this.orderGrid);
            this.Controls.Add(this.packGrid);
            this.Name = "NewOrderForm";
            this.Text = "NewOrderForm";
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView packGrid;
        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.DataGridView infoGrid;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button cancelOrderBtn;
        private System.Windows.Forms.Button confirmOrderBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button undoBtn;
    }
}