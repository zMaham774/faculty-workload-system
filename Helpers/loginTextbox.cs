using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Helpers
{
    public partial class loginTextbox : UserControl
    {
        public loginTextbox()
        {
            InitializeComponent();
        }
        //create a private fields to store the default value
        public string _label = "default value";
        public bool _isPassword = false;
        // Add a property setter that updates the UI immediately
        public string label
        {
            get { return _label; }
            set
            {
                _label = value;
                label1.Text = value;  // update label immediately
            }
        }

        public bool isPassword
        {
            get { return _isPassword; }
            set
            {
                _isPassword = value;
                textBox1.UseSystemPasswordChar = value;  // update immediately
            }
        }
        // so LoginForm can read what user typed
        public string InputText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        // clear the textbox
        public void Clear()
        {
            textBox1.Text = "";
        }
    }
}
