﻿namespace ZooEase
{
    partial class frmZooAnimlas
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbAnimals = new ComboBox();
            txtSpecies = new TextBox();
            txtCountry = new TextBox();
            btnCancel = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnLast = new Button();
            btnFirst = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpZooAnimals = new GroupBox();
            cmbZoo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            grpZooAnimals.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(120, 52);
            label1.Name = "label1";
            label1.Size = new Size(64, 19);
            label1.TabIndex = 0;
            label1.Text = "Animal :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(137, 121);
            label2.Name = "label2";
            label2.Size = new Size(44, 19);
            label2.TabIndex = 1;
            label2.Text = "Zoo :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(115, 159);
            label3.Name = "label3";
            label3.Size = new Size(71, 19);
            label3.TabIndex = 2;
            label3.Text = "Country :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(119, 87);
            label4.Name = "label4";
            label4.Size = new Size(67, 19);
            label4.TabIndex = 3;
            label4.Text = "Species :";
            // 
            // cmbAnimals
            // 
            cmbAnimals.FormattingEnabled = true;
            cmbAnimals.Location = new Point(190, 48);
            cmbAnimals.Name = "cmbAnimals";
            cmbAnimals.Size = new Size(207, 23);
            cmbAnimals.TabIndex = 4;
            cmbAnimals.Validating += cmb_Validating;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(189, 84);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.ReadOnly = true;
            txtSpecies.Size = new Size(207, 23);
            txtSpecies.TabIndex = 5;
            txtSpecies.Validating += txt_Validating;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(190, 158);
            txtCountry.Name = "txtCountry";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new Size(207, 23);
            txtCountry.TabIndex = 7;
            txtCountry.Validating += txt_Validating;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(373, 262);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 54);
            btnCancel.TabIndex = 39;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(68, 262);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 54);
            btnAdd.TabIndex = 36;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(170, 262);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 54);
            btnDelete.TabIndex = 37;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(271, 262);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 54);
            btnSave.TabIndex = 38;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(373, 207);
            btnLast.Margin = new Padding(4, 3, 4, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 50);
            btnLast.TabIndex = 35;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(68, 207);
            btnFirst.Margin = new Padding(4, 3, 4, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 50);
            btnFirst.TabIndex = 34;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(170, 207);
            btnPrevious.Margin = new Padding(4, 3, 4, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 50);
            btnPrevious.TabIndex = 33;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(271, 207);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 50);
            btnNext.TabIndex = 32;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // grpZooAnimals
            // 
            grpZooAnimals.Controls.Add(cmbZoo);
            grpZooAnimals.Controls.Add(btnCancel);
            grpZooAnimals.Controls.Add(cmbAnimals);
            grpZooAnimals.Controls.Add(btnAdd);
            grpZooAnimals.Controls.Add(label1);
            grpZooAnimals.Controls.Add(btnDelete);
            grpZooAnimals.Controls.Add(label2);
            grpZooAnimals.Controls.Add(btnSave);
            grpZooAnimals.Controls.Add(label3);
            grpZooAnimals.Controls.Add(btnLast);
            grpZooAnimals.Controls.Add(label4);
            grpZooAnimals.Controls.Add(btnFirst);
            grpZooAnimals.Controls.Add(txtSpecies);
            grpZooAnimals.Controls.Add(btnPrevious);
            grpZooAnimals.Controls.Add(btnNext);
            grpZooAnimals.Controls.Add(txtCountry);
            grpZooAnimals.Location = new Point(89, 47);
            grpZooAnimals.Name = "grpZooAnimals";
            grpZooAnimals.Size = new Size(513, 339);
            grpZooAnimals.TabIndex = 40;
            grpZooAnimals.TabStop = false;
            grpZooAnimals.Text = "groupBox1";
            // 
            // cmbZoo
            // 
            cmbZoo.FormattingEnabled = true;
            cmbZoo.Location = new Point(194, 123);
            cmbZoo.Name = "cmbZoo";
            cmbZoo.Size = new Size(202, 23);
            cmbZoo.TabIndex = 40;
            // 
            // frmZooAnimlas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 448);
            Controls.Add(grpZooAnimals);
            Name = "frmZooAnimlas";
            Text = "frmZooAnimlas";
            Load += frmZooAnimlas_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            grpZooAnimals.ResumeLayout(false);
            grpZooAnimals.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbAnimals;
        private TextBox txtSpecies;
        private TextBox txtCountry;
        private Button btnCancel;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSave;
        private Button btnLast;
        private Button btnFirst;
        private Button btnPrevious;
        private Button btnNext;
        private ErrorProvider errorProvider1;
        private GroupBox grpZooAnimals;
        private ComboBox cmbZoo;
    }
}