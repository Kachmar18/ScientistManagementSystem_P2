using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientistManagementSystem_C_
{
    public partial class addStaffForm : Form
    {
        public ScientificTeacher NewTeacher { get; private set; }

        public addStaffForm()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string lastName = txtLastName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string middleName = txtMiddleName.Text.Trim();

                // Публікації
                List<Article> articles = new List<Article>();
                foreach (string line in txtPublications.Lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 4 && int.TryParse(parts[3], out int year))
                    {
                        articles.Add(new Article(parts[0], parts[1], parts[2], year));
                    }
                    else
                    {
                        MessageBox.Show("Помилка у форматі публікації. Формат: автор;журнал;назва;рік");
                        return;
                    }
                }

                if (!int.TryParse(txtReports.Text.Trim(), out int reports) ||
                    !int.TryParse(txtPatents.Text.Trim(), out int patents) ||
                    !int.TryParse(txtHours.Text.Trim(), out int hours) ||
                    !int.TryParse(txtExperience.Text.Trim(), out int experience))
                {
                    MessageBox.Show("Перевірте числові поля: виступи, патенти, години, досвід.");
                    return;
                }

                if (cmbDegree.SelectedItem == null ||
                    !Enum.TryParse(cmbDegree.SelectedItem.ToString(), out AcademicDegree degree))
                {
                    MessageBox.Show("Будь ласка, оберіть вчений ступінь.");
                    return;
                }

                List<string> subjects = txtSubjects.Text.Split(',').Select(s => s.Trim()).Where(s => s != "").ToList();
                List<string> groups = txtGroups.Text.Split(',').Select(s => s.Trim()).Where(s => s != "").ToList();

                NewTeacher = new ScientificTeacher(
                    lastName, firstName, middleName,
                    articles.ToArray(), reports, patents, degree,
                    subjects, hours, groups, experience
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }



        private void infoStaffForm_Load(object sender, EventArgs e)
        {
            cmbDegree.Items.Clear();
            cmbDegree.Items.Add("PhD");
            cmbDegree.Items.Add("PhDM");
            cmbDegree.Items.Add("CandidateTechnical");
            cmbDegree.Items.Add("DoctorTechnical");
            cmbDegree.SelectedIndex = 0;

        }
    }
}
