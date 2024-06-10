using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooEase
{
    public partial class frmZoo_Animals : Form
    {
        public frmZoo_Animals()
        {
            InitializeComponent();
        }

        private void frmZoo_Animals_Load(object sender, EventArgs e)
        {
            try
            {
                dgvAnimals.Visible = false;
                LoadZoos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadZoos()
        {
            DataTable dt = DataAccess.GetData(
                @"SELECT ZooID, ZooName FROM Zoo ORDER BY ZooName");

            cmbZoos.DataSource = dt;
            cmbZoos.DisplayMember = "ZooName";
            cmbZoos.ValueMember = "ZooID";
            cmbZoos.SelectedIndex = -1;
        }

        private void btnShowAnimals_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbZoos.SelectedIndex >= 0)
                {
                    string zooId = cmbZoos.SelectedValue.ToString();

                    string sql = $@"
                        SELECT 
                            Animals.AnimalID, 
                            Animals.AnimalName, 
                            Animals.Habitat, 
                            Animals.Species, 
                            Animals.ReproductiveMethod 
                        FROM Zoo_Animals 
                            INNER JOIN Animals ON Zoo_Animals.AnimalID = Animals.AnimalID
                        WHERE Zoo_Animals.ZooID = {zooId}
                        ORDER BY Animals.AnimalName";

                    DataTable dt = DataAccess.GetData(sql);

                    if (dt.Rows.Count > 0)
                    {
                        dgvAnimals.Visible = true;
                        dgvAnimals.DataSource = dt;

                        dgvAnimals.ReadOnly = true;
                        dgvAnimals.AutoResizeColumns();

                        dgvAnimals.Columns["AnimalID"].Visible = false;
                        dgvAnimals.Columns["AnimalName"].HeaderText = "Animal Name";
                        dgvAnimals.Columns["AnimalName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvAnimals.Columns["Habitat"].HeaderText = "Habitat";
                        dgvAnimals.Columns["Species"].HeaderText = "Species";
                        dgvAnimals.Columns["ReproductiveMethod"].HeaderText = "Reproductive Method";
                    }
                    else
                    {
                        dgvAnimals.DataSource = null;
                        dgvAnimals.Visible = false;
                        MessageBox.Show("There are no animals in this zoo.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a zoo.");
                }
            }
            catch (Exception ex)
            {
                DisplayExceptionMessage(ex);
            }
        }

        private void DisplayExceptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
    }
}
