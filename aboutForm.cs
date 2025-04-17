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
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }


        private void linkLabelTask_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://docs.google.com/document/d/1o1IS7ZaBuRL_Kcwfkym8TMg1uuCOeBQm/edit?usp=drive_link&ouid=113111089409960470576&rtpof=true&sd=true",
                UseShellExecute = true
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void linkLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://drive.google.com/drive/folders/166VppwrMd5JoxZzhNVuo4EHBJLHOGiVf?usp=drive_link",
                UseShellExecute = true
            });
        }
    }
}
