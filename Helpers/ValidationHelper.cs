using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Helpers
{
    public class ValidationHelper
    {
        // Check if a field is empty
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        // Validate email format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true; // email is optional

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Validate phone — numbers only, 10-15 digits
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // phone is optional

            string pattern = @"^[0-9\-\+\s]{7,15}$";
            return Regex.IsMatch(phone, pattern);
        }

        // Validate name — no numbers or special chars
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            string pattern = @"^[a-zA-Z\s\.\-]+$";
            return Regex.IsMatch(name, pattern);
        }

        // Show styled error message
        public static void ShowError(string message)
        {
            MessageBox.Show(message,
                            "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        // Show success message
        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message,
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Show confirmation dialog
        public static bool Confirm(string message)
        {
            DialogResult result = MessageBox.Show(
                message,
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }
    }
}
