using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;

namespace ZooEase
{
    public partial class frmZoo : Form
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

        public frmZoo()
        {
            InitializeComponent();

            txtName.Validating += txt_Validating;
            txtCountry.Validating += txt_Validating;
            txtCity.Validating += txt_Validating;
            

            txtName.Tag = "Animal Name";
            txtCountry.Tag = "Habitat";
            txtCity.Tag = "Species";
            
        }

        #region Event Handlers

        private void frmZoo_Load(object sender, EventArgs e)
        {
            SetState(FormState.View);
            LoadFirstZoo();
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
                    MessageBox.Show("The last zoo is currently displayed");
            }
            else if (sender == btnPrevious)
            {
                if (previousId != null)
                    currentId = previousId.Value;
                else
                    MessageBox.Show("The first zoo is currently displayed");
            }
            else
            {
                return;
            }

            LoadCurrentPosition();
            DisplayCurrentZoo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this zoo?", "Are you sure", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteZoo();
                LoadFirstZoo();
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
                        if (txtZooId.Text == string.Empty)
                        {
                            CreateZoo();
                            LoadFirstZoo();
                        }
                        else
                        {
                            UpdateZoo();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetState(FormState.View);
            DisplayCurrentZoo();
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
                    UIUtilities.ClearControls(grpZoo.Controls);
                }
                DisableNavigation();
            }
        }

        private void InputsReadOnly(bool readOnly)
        {
            txtName.ReadOnly = readOnly;
            txtCountry.ReadOnly = readOnly;
            txtCity.ReadOnly = readOnly;
        }

        #endregion

        #region Load Data

        private void LoadFirstZoo()
        {
            currentId = GetFirstZooId();
            LoadCurrentPosition();
            DisplayCurrentZoo();
        }

        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();
        }

        private void LoadPositionInfo(DataRow positionRow)
        {
            int zooCount = Convert.ToInt32(positionRow["ZooCount"]);
            currentId = Convert.ToInt32(positionRow["ZooId"]);
            firstId = Convert.ToInt32(positionRow["FirstZooId"]);
            lastId = Convert.ToInt32(positionRow["LastZooId"]);
            rowNumber = Convert.ToInt32(positionRow["RowNumber"]);

            nextId = positionRow["NextZooId"] != DBNull.Value ? Convert.ToInt32(positionRow["NextZooId"]) : null;
            previousId = positionRow["PreviousZooId"] != DBNull.Value ? Convert.ToInt32(positionRow["PreviousZooId"]) : null;

            this.DisplayParentStatusStripMessage($"Display zoo {rowNumber} out of {zooCount}");
        }

        #endregion

        #region Display DataRow

        private void DisplayCurrentZoo()
        {
            DataRow currentZooRow = GetZooDataRow(currentId);
            DisplayZoo(currentZooRow);
        }

        private void DisplayZoo(DataRow selectedZoo)
        {
            txtZooId.Text = selectedZoo["ZooId"].ToString();
            txtName.Text = selectedZoo["ZooName"].ToString();
            txtCountry.Text = selectedZoo["Country"].ToString();
            txtCity.Text = selectedZoo["City"].ToString();
        }

        #endregion

        #region Get/Retrieve Data

        private int GetFirstZooId()
        {
            int id = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) ZooId FROM Zoo ORDER BY ZooName"));
            return id;
        }

        #endregion

        #region Send Data

        private void UpdateZoo()
        {
            string sqlUpdateZoo = $@"
                UPDATE Zoo
                SET ZooName = '{DataAccess.SQLFix(txtName.Text.Trim())}',
                    Country = '{DataAccess.SQLFix(txtCountry.Text)}',
                    City = '{DataAccess.SQLFix(txtCity.Text)}'
                WHERE ZooID = {DataAccess.SQLFix(txtZooId.Text)}";

            int rowsAffected = DataAccess.SendData(sqlUpdateZoo);

            if (rowsAffected == 0)
            {
                MessageBox.Show("The database reported no rows affected");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Zoo updated!");
            }
            else
            {
                MessageBox.Show("Something went wrong, please verify your data");
            }
        }

        private void CreateZoo()
        {
            string zooName = DataAccess.SQLFix(txtName.Text.Trim());

            // Get the ZooID for the specified ZooName
            int zooID = GetZooID(zooName);

            if (zooID == -1)
            {
                // Insert the new Zoo if it doesn't exist
                string sqlInsertZoo = $@"
            INSERT INTO Zoo (ZooName, Country, City)
            VALUES ('{zooName}', '{DataAccess.SQLFix(txtCountry.Text)}', '{DataAccess.SQLFix(txtCity.Text)}')";

                int rowsAffected = DataAccess.SendData(sqlInsertZoo);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Zoo created.");
                }
                else
                {
                    MessageBox.Show("The database reported no rows affected.");
                }
            }
            else if (GetAnimalCountForZoo(zooID) < 3)
            {
                MessageBox.Show("The zoo already exists but it has less than 3 animals.");
            }
            else
            {
                MessageBox.Show("The zoo cannot be created because it already has 3 animals assigned.");
            }
        }

        private int GetZooID(string zooName)
        {
            string sqlGetZooID = $@"
        SELECT ZooID
        FROM Zoo
        WHERE ZooName = '{zooName}'";

            object result = DataAccess.GetValue(sqlGetZooID);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private int GetAnimalCountForZoo(int zooID)
        {
            string sqlCountAnimals = $@"
        SELECT COUNT(*) 
        FROM Zoo_Animals 
        WHERE ZooID = {zooID}";

            return Convert.ToInt32(DataAccess.GetValue(sqlCountAnimals));
        }


        private void DeleteZoo()
        {
            string sqlDelete = $"DELETE FROM Zoo WHERE ZooId = {txtZooId.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Zoo was deleted");
            }
            else
            {
                MessageBox.Show("The database reported no rows affected");
            }
        }

        #endregion

        #region Get Data Row

        private DataRow GetZooDataRow(int id)
        {
            string sqlZooById = $"SELECT * FROM Zoo WHERE ZooID = {id}";

            DataTable dt = DataAccess.GetData(sqlZooById);

            return dt.Rows[0];
        }

        private DataRow GetPositionDataRow(int id)
        {
            string sqlNav = $@"
                SELECT 
                    (Select Count (1) from Zoo) as ZooCount,
                    ZooID,
                    (SELECT TOP(1) ZooID FROM Zoo ORDER BY ZooName) as FirstZooId,
                    q.PreviousZooId,
                    q.NextZooId,
                    (SELECT TOP(1) ZooID FROM Zoo ORDER BY ZooName DESC) as LastZooId,
                    q.RowNumber
                FROM
                (
                    SELECT ZooID, ZooName,
                        LEAD(ZooId) OVER(ORDER BY ZooName) AS NextZooId,
                        LAG(ZooId) OVER(ORDER BY ZooName) AS PreviousZooId,
                        ROW_NUMBER() OVER(ORDER BY ZooName) AS 'RowNumber'
                    FROM Zoo
                ) AS q
                WHERE q.ZooID = {id}
                ORDER BY q.ZooName";

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
