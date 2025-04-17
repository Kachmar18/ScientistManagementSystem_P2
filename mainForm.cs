using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientistManagementSystem_C_
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void проПрограмуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            infoStaffForm infoStaffForm = new infoStaffForm();
            infoStaffForm.ShowDialog();
        }

        private void проПрограмуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();  
            aboutForm.ShowDialog();
        }

        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
