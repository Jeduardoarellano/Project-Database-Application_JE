namespace ZooEase
{
    partial class frmZoo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            grpZoo = new GroupBox();
            btnCancel = new Button();
            txtZooId = new TextBox();
            btnLast = new Button();
            btnAdd = new Button();
            label4 = new Label();
            btnDelete = new Button();
            btnFirst = new Button();
            txtName = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            btnPrevious = new Button();
            txtCountry = new TextBox();
            btnNext = new Button();
            label2 = new Label();
            txtCity = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            grpZoo.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // grpZoo
            // 
            grpZoo.BackColor = Color.Transparent;
            grpZoo.Controls.Add(btnCancel);
            grpZoo.Controls.Add(txtZooId);
            grpZoo.Controls.Add(btnLast);
            grpZoo.Controls.Add(btnAdd);
            grpZoo.Controls.Add(label4);
            grpZoo.Controls.Add(btnDelete);
            grpZoo.Controls.Add(btnFirst);
            grpZoo.Controls.Add(txtName);
            grpZoo.Controls.Add(btnSave);
            grpZoo.Controls.Add(label1);
            grpZoo.Controls.Add(btnPrevious);
            grpZoo.Controls.Add(txtCountry);
            grpZoo.Controls.Add(btnNext);
            grpZoo.Controls.Add(label2);
            grpZoo.Controls.Add(txtCity);
            grpZoo.Controls.Add(label3);
            grpZoo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpZoo.Location = new Point(139, 106);
            grpZoo.Name = "grpZoo";
            grpZoo.Size = new Size(557, 332);
            grpZoo.TabIndex = 2;
            grpZoo.TabStop = false;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(387, 274);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 50;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtZooId
            // 
            txtZooId.Location = new Point(198, 47);
            txtZooId.Name = "txtZooId";
            txtZooId.ReadOnly = true;
            txtZooId.Size = new Size(60, 23);
            txtZooId.TabIndex = 52;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(387, 234);
            btnLast.Margin = new Padding(4);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 32);
            btnLast.TabIndex = 46;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnAdd.Location = new Point(83, 274);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 47;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(169, 50);
            label4.Name = "label4";
            label4.Size = new Size(23, 15);
            label4.TabIndex = 51;
            label4.Text = "ID:";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(185, 274);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 48;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(83, 234);
            btnFirst.Margin = new Padding(4);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 32);
            btnFirst.TabIndex = 45;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // txtName
            // 
            txtName.Location = new Point(198, 85);
            txtName.Name = "txtName";
            txtName.Size = new Size(217, 23);
            txtName.TabIndex = 38;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnSave.Location = new Point(286, 274);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 49;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(149, 88);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 37;
            label1.Text = "Name:";
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(185, 234);
            btnPrevious.Margin = new Padding(4);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 32);
            btnPrevious.TabIndex = 44;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(198, 123);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(217, 23);
            txtCountry.TabIndex = 40;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(286, 234);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 32);
            btnNext.TabIndex = 43;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(138, 126);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 39;
            label2.Text = "Country:";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(198, 162);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(217, 23);
            txtCity.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(161, 165);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 41;
            label3.Text = "City:";
            // 
            // frmZoo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zoo_form;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(grpZoo);
            Name = "frmZoo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += frmZoo_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            grpZoo.ResumeLayout(false);
            grpZoo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
        private GroupBox grpZoo;
        private Button btnCancel;
        private TextBox txtZooId;
        private Button btnLast;
        private Button btnAdd;
        private Label label4;
        private Button btnDelete;
        private Button btnFirst;
        private TextBox txtName;
        private Button btnSave;
        private Label label1;
        private Button btnPrevious;
        private TextBox txtCountry;
        private Button btnNext;
        private Label label2;
        private TextBox txtCity;
        private Label label3;
    }
}
