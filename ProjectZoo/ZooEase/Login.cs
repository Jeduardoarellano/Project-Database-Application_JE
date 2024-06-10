using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooEase
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - Login";

            txtUserName.Text = Environment.UserName;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidLogin())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private bool IsValidLogin()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ZooEase"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", txtUserName.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);

                try
                {
                    connection.Open();
                    int result = (int)command.ExecuteScalar();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    return false;
                }
            }
        }
    }
}
