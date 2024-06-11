using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ZooEase
{
    public partial class frmZooAnimlas : Form
    {
        int currentAnimalId;
        int firstAnimalId;
        int lastAnimalId;
        int? previousAnimalId;
        int? nextAnimalId;

        int currentZooId;
        int firstZooId;
        int lastZooId;
        int? previousZooId;
        int? nextZooId;


        private FormState currentState;

        public frmZooAnimlas()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void frmZooAnimlas_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAnimals();
                LoadZoos();
                LoadFirstZoo_Animal();
                EnableNavigation(true);

                cmbAnimals.SelectedIndexChanged += cmbAnimals_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAnimals();
                LoadZoos();
                SetState(FormState.Add);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Animal", "Are you sure?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteAnimal();
                    LoadFirstZoo_Animal();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    if (currentState == FormState.View)
                    {
                        SetState(FormState.Edit);
                    }
                    else
                    {
                        if (currentState == FormState.Add)
                        {
                            CreateAnimal();
                            LoadFirstZoo_Animal();
                        }
                        else
                        {
                            MessageBox.Show("Please resolve your validation errors");
                        }

                        SetState(FormState.View);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SetState(FormState.View);
                LoadCurrentPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);
        }

        private void LoadState(FormState state)
        {
            if (state == FormState.View)
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Edit";
                AllowInputs(false);
                errorProvider1.Clear();
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";

                AllowInputs(true);
                if (state == FormState.Add)
                {
                    grpZooAnimals.ClearChildControls(defaultSelectedIndex: -1);
                }
            }

            EnableNavigation(currentState == FormState.View);
        }


        private void AllowInputs(bool allowInput)
        {
            txtSpecies.ReadOnly = !allowInput;
            txtCountry.ReadOnly = !allowInput;
            cmbZoo.Enabled = allowInput;
            cmbAnimals.Enabled = allowInput;
        }

        #endregion

        private void cmbAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAnimals.SelectedIndex != -1)
                {
                    currentAnimalId = Convert.ToInt32(cmbAnimals.SelectedValue);
                    currentZooId = Convert.ToInt32(cmbZoo.SelectedValue);
                    LoadAnimalDetails(currentAnimalId, currentZooId);
                    LoadCurrentPosition();
                    EnableNavigation(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadAnimals()
        {
            string sqlAnimals = "SELECT AnimalId, AnimalName FROM Animals ORDER BY AnimalName";
            DataTable dtAnimals = DataAccess.GetData(sqlAnimals);

            cmbAnimals.DisplayMember = "AnimalName";
            cmbAnimals.ValueMember = "AnimalId";
            cmbAnimals.DataSource = dtAnimals;

            cmbAnimals.SelectedIndex = -1;
        }


        private void LoadZoos()
        {
            string sqlZoo = "SELECT ZooId, ZooName FROM Zoo ORDER BY ZooName";
            DataTable dtZoo = DataAccess.GetData(sqlZoo);

            cmbZoo.DisplayMember = "ZooName";
            cmbZoo.ValueMember = "ZooId";
            cmbZoo.DataSource = dtZoo;

            cmbZoo.SelectedIndex = -1;
        }

        private void LoadAnimalDetails(int animalId, int zooId)
        {
            string sql = $@"
                SELECT a.AnimalId, a.AnimalName, a.Species, z.ZooId, z.Country 
                FROM Animals a
                JOIN Zoo_Animals za ON a.AnimalId = za.AnimalId
                JOIN Zoo z ON za.ZooId = z.ZooId
                WHERE a.AnimalId = {animalId}";

            DataTable dtAnimalDetails = DataAccess.GetData(sql);

            if (dtAnimalDetails.Rows.Count > 0)
            {
                DataRow row = dtAnimalDetails.Rows[0];
                txtSpecies.Text = row["Species"].ToString();
                cmbAnimals.SelectedValue = Convert.ToInt32(row["AnimalId"].ToString());
                cmbZoo.SelectedValue = Convert.ToInt32(row["ZooId"].ToString());
                txtCountry.Text = row["Country"].ToString();
            }

        }

        private void LoadFirstZoo_Animal()
        {
            string sql = @"
                    SELECT TOP 1 a.AnimalId, a.ZooID 
                    FROM Zoo_Animals a
                    JOIN Animals za ON a.AnimalId = za.AnimalId
                    ORDER BY a.AnimalID";

            DataTable firstAnimal = DataAccess.GetData(sql);
            if (firstAnimal.Rows.Count > 0)
            {
                firstAnimalId = Convert.ToInt32(firstAnimal.Rows[0]["AnimalId"]);
                currentAnimalId = firstAnimalId;

                firstZooId = Convert.ToInt32(firstAnimal.Rows[0]["ZooId"]);
                currentZooId = firstZooId;

                LoadAnimalDetails(currentAnimalId, currentZooId);
                LoadCurrentPosition();
            }
        }

        private void LoadCurrentPosition()
        {
            string sql = $@"
                SELECT
                    z.NextAnimalId,
                    z.NextZooId,
                    z.PreviousAnimalId,
                    z.PreviousZooId,
                    z.RowNumber,
                    (SELECT TOP 1 AnimalId FROM Zoo_Animals ORDER BY AnimalId) AS FirstAnimalId,
                    (SELECT TOP 1 ZooId FROM Zoo_Animals ORDER BY ZooID) AS FirstZooId,
                    (SELECT TOP 1 AnimalId FROM Zoo_Animals ORDER BY AnimalId DESC) AS LastAnimalId,
                    (SELECT TOP 1 ZooId FROM Zoo_Animals ORDER BY ZooID DESC) AS LastZooId
                    
                FROM(
                    SELECT AnimalId, ZooId,
                        LEAD(AnimalId) OVER (ORDER BY AnimalId) AS NextAnimalId,
                        LEAD(ZooId) OVER (ORDER BY AnimalId) AS NextZooId,

                        LAG(AnimalId) OVER (ORDER BY AnimalId) AS PreviousAnimalId,
                        LAG(ZooId) OVER (ORDER BY AnimalId) AS PreviousZooId,
		                ROW_NUMBER() Over(Order by AnimalId) as RowNumber
                    FROM Zoo_Animals) AS z
                WHERE AnimalId = {currentAnimalId} AND ZooId = {currentZooId}";


            DataTable dt = DataAccess.GetData(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                firstAnimalId = Convert.ToInt32(row["FirstAnimalId"]);
                lastAnimalId = Convert.ToInt32(row["LastAnimalId"]);

                firstZooId = Convert.ToInt32(row["FirstZooId"]);
                lastZooId = Convert.ToInt32(row["LastZooId"]);

                previousAnimalId = row["PreviousAnimalId"] != DBNull.Value ? Convert.ToInt32(row["PreviousAnimalId"]) : null;
                nextAnimalId = row["NextAnimalId"] != DBNull.Value ? Convert.ToInt32(row["NextAnimalId"]) : null;

                previousZooId = row["PreviousZooId"] != DBNull.Value ? Convert.ToInt32(row["PreviousZooId"]) : null;
                nextZooId = row["NextZooId"] != DBNull.Value ? Convert.ToInt32(row["NextZooId"]) : null;
            }
        }

        #region Navigation
        private void Navigation_Handler(object sender, EventArgs e)
        {
            if (sender == btnFirst)
            {
                currentAnimalId = firstAnimalId;
                currentZooId = firstZooId;
            }
            else if (sender == btnNext)
            {
                currentAnimalId = nextAnimalId.Value;
                currentZooId = nextZooId.Value;
            }
            else if (sender == btnPrevious)
            {
                currentAnimalId = previousAnimalId.Value;
                currentZooId = previousZooId.Value;
            }
            else if (sender == btnLast)
            {
                currentAnimalId = lastAnimalId;
                currentZooId = lastZooId;
            }
            else
            {
                return;
            }

            LoadAnimalDetails(currentAnimalId, currentZooId);
            LoadCurrentPosition();
            //EnableNavigation(true);
        }

        private void EnableNavigation(bool enable)
        {
            if (enable)
            {
                btnPrevious.Enabled = previousAnimalId != null && previousZooId != null;
                btnNext.Enabled = nextAnimalId != null && nextZooId != null;

                btnNext.Enabled = nextAnimalId != null
                    && nextZooId != null;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }

            btnFirst.Enabled = enable;
            btnLast.Enabled = enable;
        }
        #endregion


        #region Send Data

        private void CreateAnimal()
        {
            try
            {
                string species = txtSpecies.Text.Trim();
                string zooId = cmbZoo.SelectedValue.ToString();
                string country = txtCountry.Text.Trim();

                string sql = $@"
                    INSERT INTO Animals (Species, ZooId, Country)
                    VALUES ('{species}', 
                    (SELECT TOP 1 ZooId FROM Zoo WHERE ZooId = {zooId}), 
                    '{country}')";

                int rowsAffected = DataAccess.SendData(sql);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Animal was created");
                    LoadAnimals();
                    LoadFirstZoo_Animal();
                }
                else
                {
                    MessageBox.Show("Failed to save Animal. Ensure the zoo exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DeleteAnimal()
        {
            try
            {
                string sql = $@"DELETE FROM Animals WHERE AnimalId = {currentAnimalId}";

                int rowsAffected = DataAccess.SendData(sql);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Animal was deleted");
                    LoadFirstZoo_Animal();
                }
                else
                {
                    MessageBox.Show("The database reports no rows affected, verify your data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        #endregion

        #region Validation
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox? txt = sender as TextBox;
            if (txt == null)
                return;

            string? errorMessage = string.Empty;

            if (txt.Text == string.Empty)
            {
                errorMessage = $"{txt.Tag} is required";
                //e.Cancel = true;
            }

            this.errorProvider1.SetError(txt, errorMessage);
        }

        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox? cmb = sender as ComboBox;
            if (cmb == null) return;

            string errorMessage = string.Empty;

            if (cmb.SelectedIndex == -1)
            {
                errorMessage = $"{cmb.Tag} is required";
                //e.Cancel = true;
            }

            this.errorProvider1.SetError(cmb, errorMessage);
        }

#endregion
    }
}
