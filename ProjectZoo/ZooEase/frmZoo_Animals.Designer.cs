namespace ZooEase
{
    partial class frmZoo_Animals
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
            button1 = new Button();
            dgvAnimals = new DataGridView();
            cmbZoos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(517, 103);
            button1.Name = "button1";
            button1.Size = new Size(118, 30);
            button1.TabIndex = 5;
            button1.Text = "Show Animals";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnShowAnimals_Click;
            // 
            // dgvAnimals
            // 
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Location = new Point(114, 226);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.Size = new Size(573, 179);
            dgvAnimals.TabIndex = 4;
            // 
            // cmbZoos
            // 
            cmbZoos.FormattingEnabled = true;
            cmbZoos.Location = new Point(286, 108);
            cmbZoos.Name = "cmbZoos";
            cmbZoos.Size = new Size(210, 23);
            cmbZoos.TabIndex = 1;
            // 
            // frmZoo_Animals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.zoo_select;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbZoos);
            Controls.Add(button1);
            Controls.Add(dgvAnimals);
            Name = "frmZoo_Animals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmZoo_Animals";
            Load += frmZoo_Animals_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dgvAnimals;
        private ComboBox cmbZoos;
    }
}