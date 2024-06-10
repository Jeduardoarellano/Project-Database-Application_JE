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
    public partial class frmAnimals_Zoo : Form
    {
        public frmAnimals_Zoo()
        {
            InitializeComponent();
        }

        private void frmAnimals_Zoo_Load(object sender, EventArgs e)
        {
            try
            {
                dgvZoos.Visible = false;
                LoadAnimals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadAnimals()
        {
            DataTable dt = DataAccess.GetData(
                @"SELECT AnimalID, AnimalName FROM Animals ORDER BY AnimalName");

            cmbAnimals.DataSource = dt;
            cmbAnimals.DisplayMember = "AnimalName";
            cmbAnimals.ValueMember = "AnimalID";
            cmbAnimals.SelectedIndex = -1;
        }

        private void btnShowZoos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAnimals.SelectedIndex >= 0)
                {
                    string animalId = cmbAnimals.SelectedValue.ToString();

                    string sql = $@"
                        SELECT 
                            Zoo.ZooID, 
                            Zoo.ZooName, 
                            Zoo.Country, 
                            Zoo.City 
                        FROM Zoo_Animals 
                            INNER JOIN Zoo ON Zoo_Animals.ZooID = Zoo.ZooID
                        WHERE Zoo_Animals.AnimalID = {animalId}
                        ORDER BY Zoo.ZooName";

                    DataTable dt = DataAccess.GetData(sql);

                    if (dt.Rows.Count > 0)
                    {
                        dgvZoos.Visible = true;
                        dgvZoos.DataSource = dt;

                        dgvZoos.ReadOnly = true;
                        dgvZoos.AutoResizeColumns();

                        dgvZoos.Columns["ZooID"].Visible = false;
                        dgvZoos.Columns["ZooName"].HeaderText = "Zoo Name";
                        dgvZoos.Columns["ZooName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvZoos.Columns["Country"].HeaderText = "Country";
                        dgvZoos.Columns["City"].HeaderText = "City";
                    }
                    else
                    {
                        dgvZoos.DataSource = null;
                        dgvZoos.Visible = false;
                        MessageBox.Show("There are no zoos with this animal.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an animal.");
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
