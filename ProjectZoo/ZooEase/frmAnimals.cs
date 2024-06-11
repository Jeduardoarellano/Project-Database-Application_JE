using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooEase
{
    public partial class frmAnimals : Form
    {

        #region Private Fields

        private int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId;
        private FormState currentState;
        private int rowNumber;


        #endregion

        public frmAnimals()
        {
            InitializeComponent();

            txtAnimalName.Tag = "Animal Name";
            txtHabitat.Tag = "Habitat";
            txtSpecies.Tag = "Species";
            txtReproductiveMethod.Tag = "Reproductive Method";
        }

        #region Event Handlers
        private void frmAnimals_Load(object sender, EventArgs e)
        {
            SetState(FormState.View);
            LoadFirstAnimal();
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            if (sender == btnFirst)
            {
                currentId = firstId;
            }
            else if (sender == btnLast)
            {
                currentId = lastId;
            }
            else if (sender == btnNext)
            {
                if (nextId != null)
                    currentId = nextId.Value;
                else
                    MessageBox.Show("The last animal is currently displayed");
            }
            else if (sender == btnPrevious)
            {
                if (previousId != null)
                    currentId = previousId.Value;
                else
                    MessageBox.Show("The first animal is currently displayed");
            }
            else
            {
                return;
            }

            LoadCurrentPosition();
            DisplayCurrentAnimal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this animal?", "Are you sure", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteAnimal();
                LoadFirstAnimal();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (ValidateChildren())
                    {
                        if (txtAnimalId.Text == string.Empty)
                        {
                            if (!IsDuplicateHabitat(txtHabitat.Text.Trim()))
                            {
                                CreateAnimal();
                                LoadFirstAnimal();
                            }
                            else
                            {
                                MessageBox.Show("An animal with this habitat already exists.");
                            }
                        }
                        else
                        {
                            UpdateAnimal();
                        }

                        SetState(FormState.View);
                    }
                    else
                    {
                        MessageBox.Show("Please resolve your validation errors");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Sql related error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private bool IsDuplicateHabitat(string habitat)
        {
            string sqlCheckDuplicate = $"SELECT COUNT(*) FROM Animals WHERE Habitat = '{habitat}'";
            int count = Convert.ToInt32(DataAccess.GetValue(sqlCheckDuplicate));
            return count > 0;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetState(FormState.View);
            DisplayCurrentAnimal();
        }

        #endregion

        #region Navigation Management

        private void NavigationButtonManagement()
        {
            btnPrevious.Enabled = previousId != null;
            btnNext.Enabled = nextId != null;
            btnFirst.Enabled = currentId != firstId;
            btnLast.Enabled = currentId != lastId;
        }

        private void DisableNavigation()
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
        }

        #endregion

        #region Form State

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
                InputsReadOnly(true);
                NavigationButtonManagement();
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                InputsReadOnly(false);
                if (state == FormState.Add)
                {
                    UIUtilities.ClearControls(grpAnimal.Controls);
                }
                DisableNavigation();
            }
        }

        private void InputsReadOnly(bool readOnly)
        {
            txtAnimalName.ReadOnly = readOnly;
            txtHabitat.ReadOnly = readOnly;
            txtSpecies.ReadOnly = readOnly;
            txtReproductiveMethod.ReadOnly = readOnly;
        }

        #endregion

        #region Load Data

        private void LoadFirstAnimal()
        {
            currentId = GetFirstAnimalId();
            LoadCurrentPosition();
            DisplayCurrentAnimal();
        }

        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();

        }

        private void LoadPositionInfo(DataRow positionRow)
        {
            int animalCount = Convert.ToInt32(positionRow["AnimalCount"]);
            currentId = Convert.ToInt32(positionRow["AnimalId"]);
            firstId = Convert.ToInt32(positionRow["FirstAnimalId"]);
            lastId = Convert.ToInt32(positionRow["LastAnimalId"]);
            rowNumber = Convert.ToInt32(positionRow["RowNumber"]);

            nextId = positionRow["NextAnimalId"] != DBNull.Value ? Convert.ToInt32(positionRow["NextAnimalId"]) : null;
            previousId = positionRow["PreviousAnimalId"] != DBNull.Value ? Convert.ToInt32(positionRow["PreviousAnimalId"]) : null;

            this.DisplayParentStatusStripMessage($"Display animal {rowNumber} out of {animalCount}");
        }

        #endregion

        #region Display DataRow

        private void DisplayCurrentAnimal()
        {
            DataRow currentAnimalRow = GetAnimalDataRow(currentId);
            DisplayAnimal(currentAnimalRow);
        }

        private void DisplayAnimal(DataRow selectedAnimal)
        {
            txtAnimalId.Text = selectedAnimal["AnimalId"].ToString();
            txtAnimalName.Text = selectedAnimal["AnimalName"].ToString();
            txtHabitat.Text = selectedAnimal["Habitat"].ToString();
            txtSpecies.Text = selectedAnimal["Species"].ToString();
            txtReproductiveMethod.Text = selectedAnimal["ReproductiveMethod"].ToString();
        }

        #endregion

        #region Get/Retrieve Data

        private int GetFirstAnimalId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) AnimalId FROM Animals ORDER BY AnimalName"));
            return id;
        }

        #endregion

        #region Send Data

        private void UpdateAnimal()
        {
            string sqlUpdateAnimal = $@"
                UPDATE Animals
                SET AnimalName = '{DataAccess.SQLFix(txtAnimalName.Text.Trim())}',
                    Habitat = '{DataAccess.SQLFix(txtHabitat.Text)}',
                    Species = '{DataAccess.SQLFix(txtSpecies.Text)}',
                    ReproductiveMethod = '{DataAccess.SQLFix(txtReproductiveMethod.Text)}'
                WHERE AnimalID = {txtAnimalId.Text}";

            int rowsAffected = DataAccess.SendData(sqlUpdateAnimal);

            if (rowsAffected == 0)
            {
                MessageBox.Show("The database reported no rows affected");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Animal updated!");
            }
            else
            {
                MessageBox.Show("Something went wrong, please verify your data");
            }
        }

        private void CreateAnimal()
        {
            string sqlInsertAnimal = $@"
                INSERT INTO Animals (AnimalName, Habitat, Species, ReproductiveMethod)
                VALUES ('{DataAccess.SQLFix(txtAnimalName.Text.Trim())}', 
                '{DataAccess.SQLFix(txtHabitat.Text)}', 
                '{DataAccess.SQLFix(txtSpecies.Text)}', 
                '{DataAccess.SQLFix(txtReproductiveMethod.Text)}')";

            int rowsAffected = DataAccess.SendData(sqlInsertAnimal);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Animal created.");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected.");
            }
        }

        private void DeleteAnimal()
        {
            string sqlDelete = $"DELETE FROM Animals WHERE AnimalId = {txtAnimalId.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Animal was deleted");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected");
            }
        }

        #endregion

        #region Get Data Row

        private DataRow GetAnimalDataRow(int id)
        {
            string sqlAnimalById = $"SELECT * FROM Animals WHERE AnimalID = {id}";

            DataTable dt = DataAccess.GetData(sqlAnimalById);

            return dt.Rows[0];
        }

        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
                SELECT 
                    (Select Count (1) from Animals) as AnimalCount,
                    AnimalID,
                    (SELECT TOP(1) AnimalID FROM Animals ORDER BY AnimalName) as FirstAnimalId,
                    q.PreviousAnimalId,
                    q.NextAnimalId,
                    (SELECT TOP(1) AnimalID FROM Animals ORDER BY AnimalName DESC) as LastAnimalId,
                    q.RowNumber
                FROM
                (
                    SELECT AnimalID, AnimalName,
                        LEAD(AnimalId) OVER(ORDER BY AnimalName) AS NextAnimalId,
                        LAG(AnimalId) OVER(ORDER BY AnimalName) AS PreviousAnimalId,
                        ROW_NUMBER() OVER(ORDER BY AnimalName) AS 'RowNumber'
                    FROM Animals
                ) AS q
                WHERE q.AnimalID = {id}
                ORDER BY q.AnimalName";

            DataTable dt = DataAccess.GetData(sqlNav);

            return dt.Rows[0];
        }

        #endregion

        #region Validation

        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string? errMsg = null;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txt.Tag} is required.";
                //e.Cancel = true;
            }

            errorProvider1.SetError(txt, errMsg);
        }

        #endregion
    }
}
