namespace ZooEase
{
    partial class frmAnimals
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
            label5 = new Label();
            grpAnimal = new GroupBox();
            btnCancel = new Button();
            txtAnimalId = new TextBox();
            txtSpecies = new TextBox();
            btnAdd = new Button();
            txtHabitat = new TextBox();
            btnDelete = new Button();
            txtReproductiveMethod = new TextBox();
            btnLast = new Button();
            txtAnimalName = new TextBox();
            btnSave = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(186, 34);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(167, 70);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(159, 100);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Habitat:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(158, 136);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Species:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(77, 169);
            label5.Name = "label5";
            label5.Size = new Size(133, 15);
            label5.TabIndex = 4;
            label5.Text = "Reproductive Method:";
            // 
            // grpAnimal
            // 
            grpAnimal.BackColor = Color.Transparent;
            grpAnimal.Controls.Add(btnCancel);
            grpAnimal.Controls.Add(txtAnimalId);
            grpAnimal.Controls.Add(txtSpecies);
            grpAnimal.Controls.Add(btnAdd);
            grpAnimal.Controls.Add(txtHabitat);
            grpAnimal.Controls.Add(btnDelete);
            grpAnimal.Controls.Add(txtReproductiveMethod);
            grpAnimal.Controls.Add(btnLast);
            grpAnimal.Controls.Add(txtAnimalName);
            grpAnimal.Controls.Add(btnSave);
            grpAnimal.Controls.Add(btnNext);
            grpAnimal.Controls.Add(label1);
            grpAnimal.Controls.Add(label3);
            grpAnimal.Controls.Add(btnPrevious);
            grpAnimal.Controls.Add(label4);
            grpAnimal.Controls.Add(label5);
            grpAnimal.Controls.Add(btnFirst);
            grpAnimal.Controls.Add(label2);
            grpAnimal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpAnimal.Location = new Point(145, 110);
            grpAnimal.Name = "grpAnimal";
            grpAnimal.Size = new Size(557, 318);
            grpAnimal.TabIndex = 5;
            grpAnimal.TabStop = false;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(362, 274);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 26);
            btnCancel.TabIndex = 42;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new Point(227, 31);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.ReadOnly = true;
            txtAnimalId.Size = new Size(46, 23);
            txtAnimalId.TabIndex = 5;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(227, 133);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(213, 23);
            txtSpecies.TabIndex = 8;
            txtSpecies.Validating += txt_Validating;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnAdd.Location = new Point(103, 274);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(79, 26);
            btnAdd.TabIndex = 39;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtHabitat
            // 
            txtHabitat.Location = new Point(227, 96);
            txtHabitat.Name = "txtHabitat";
            txtHabitat.Size = new Size(213, 23);
            txtHabitat.TabIndex = 7;
            txtHabitat.Validating += txt_Validating;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(187, 274);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 26);
            btnDelete.TabIndex = 40;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtReproductiveMethod
            // 
            txtReproductiveMethod.Location = new Point(227, 166);
            txtReproductiveMethod.Name = "txtReproductiveMethod";
            txtReproductiveMethod.Size = new Size(213, 23);
            txtReproductiveMethod.TabIndex = 9;
            txtReproductiveMethod.Validating += txt_Validating;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(361, 234);
            btnLast.Margin = new Padding(4);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(79, 29);
            btnLast.TabIndex = 38;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // txtAnimalName
            // 
            txtAnimalName.Location = new Point(227, 67);
            txtAnimalName.Name = "txtAnimalName";
            txtAnimalName.Size = new Size(213, 23);
            txtAnimalName.TabIndex = 6;
            txtAnimalName.Validating += txt_Validating;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnSave.Location = new Point(274, 274);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 26);
            btnSave.TabIndex = 41;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(274, 234);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(79, 29);
            btnNext.TabIndex = 35;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(187, 234);
            btnPrevious.Margin = new Padding(4);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(79, 29);
            btnPrevious.TabIndex = 36;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(103, 234);
            btnFirst.Margin = new Padding(4);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(79, 29);
            btnFirst.TabIndex = 37;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAnimals
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Animals_form;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(grpAnimal);
            Name = "frmAnimals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAnimals";
            Load += frmAnimals_Load;
            grpAnimal.ResumeLayout(false);
            grpAnimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox grpAnimal;
        private TextBox txtReproductiveMethod;
        private TextBox txtSpecies;
        private TextBox txtHabitat;
        private TextBox txtAnimalName;
        private TextBox txtAnimalId;
        private Button btnCancel;
        private Button btnLast;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnFirst;
        private Button btnSave;
        private Button btnPrevious;
        private Button btnNext;
        private ErrorProvider errorProvider1;
    }
}