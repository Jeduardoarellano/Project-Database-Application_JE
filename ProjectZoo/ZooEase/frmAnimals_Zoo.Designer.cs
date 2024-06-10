namespace ZooEase
{
    partial class frmAnimals_Zoo
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
            cmbAnimals = new ComboBox();
            dgvZoos = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvZoos).BeginInit();
            SuspendLayout();
            // 
            // cmbAnimals
            // 
            cmbAnimals.FormattingEnabled = true;
            cmbAnimals.Location = new Point(337, 118);
            cmbAnimals.Name = "cmbAnimals";
            cmbAnimals.Size = new Size(210, 23);
            cmbAnimals.TabIndex = 1;
            // 
            // dgvZoos
            // 
            dgvZoos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZoos.Location = new Point(88, 206);
            dgvZoos.Name = "dgvZoos";
            dgvZoos.Size = new Size(654, 173);
            dgvZoos.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(576, 112);
            button1.Name = "button1";
            button1.Size = new Size(151, 32);
            button1.TabIndex = 2;
            button1.Text = "Show Zoos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnShowZoos_Click;
            // 
            // frmAnimals_Zoo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.animal_select1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbAnimals);
            Controls.Add(button1);
            Controls.Add(dgvZoos);
            Name = "frmAnimals_Zoo";
            Text = "frmAnimals_Zoo";
            Load += frmAnimals_Zoo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvZoos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbAnimals;
        private DataGridView dgvZoos;
        private Button button1;
    }
}