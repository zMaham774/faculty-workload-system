using FacultyWorkloadSystem.DAL;
using FacultyWorkloadSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Read inputs
            string username = loginTextbox1.InputText.Trim();
            string password = loginTextbox2.InputText.Trim();
            // Validate not empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Validation", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //Hash the password
                string hashedPassword = PasswordHelper.HashPassword(password);
                //Check database
                DataRow user = UserDAL.GetUserByCredentials(username, hashedPassword);
                // Handle result
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.\n" +"Please try again.", "Login Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    loginTextbox2.Clear();
                    return;
                }
                // Save to session
                SessionManager.UserId = Convert.ToInt32(user["user_id"]);
                SessionManager.Username = user["username"].ToString();
                SessionManager.Role = user["role"].ToString();
                SessionManager.EmpId = user["emp_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(user["emp_id"]);
                UserDAL.UpdateLastLogin(SessionManager.UserId);
                // Log it
                LogManager.LogInfo($"User '{username}' logged in " + $"with role '{SessionManager.Role}'");
                // Temporary success message
                MessageBox.Show("Login Successful!\n\n" +"Welcome:  " + SessionManager.Username +"\nRole:    " + SessionManager.Role,"Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                MessageBox.Show("An error occurred during login.\n" +"Please check your connection.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, isPassword becomes false (shows text)
            // If unchecked, isPassword becomes true (hides text)
            loginTextbox2.isPassword = !chkShowPassword.Checked;
        }
    }
}

