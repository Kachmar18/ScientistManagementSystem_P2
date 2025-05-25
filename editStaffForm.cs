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
    public partial class editStaffForm : Form
    {
        public ScientificTeacher EditedTeacher { get; private set; }

        public editStaffForm()
        {
            InitializeComponent();
        }

        public void LoadTeacherForEdit(ScientificTeacher teacher)
        {
            txtLastName.Text = teacher.LastName;
            txtFirstName.Text = teacher.FirstName;
            txtMiddleName.Text = teacher.MiddleName;

            txtPublications.Lines = teacher.Publications
                .Select(a => $"{a.Authors};{a.JournalName};{a.Title};{a.Year}")
                .ToArray();

            txtReports.Text = teacher.ConferenceReports.ToString();
            txtPatents.Text = teacher.Patents.ToString();
            cmbDegree.SelectedItem = teacher.Degree.ToString();

            txtSubjects.Text = string.Join(", ", teacher.TeacherData.Subjects);
            txtHours.Text = teacher.TeacherData.AnnualHours.ToString();
            txtGroups.Text = string.Join(", ", teacher.TeacherData.Groups);
            txtExperience.Text = teacher.TeacherData.ExperienceYears.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string lastName = txtLastName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string middleName = txtMiddleName.Text.Trim();

                List<Article> articles = new List<Article>();
                foreach (string line in txtPublications.Lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 4 && int.TryParse(parts[3], out int year))
                    {
                        articles.Add(new Article(parts[0], parts[1], parts[2], year));
                    }
                }

                if (!int.TryParse(txtReports.Text, out int reports) ||
                    !int.TryParse(txtPatents.Text, out int patents) ||
                    !int.TryParse(txtHours.Text, out int hours) ||
                    !int.TryParse(txtExperience.Text, out int experience))
                {
                    MessageBox.Show("Перевірте числові поля.");
                    return;
                }

                if (!Enum.TryParse(cmbDegree.SelectedItem.ToString(), out AcademicDegree degree))
                {
                    MessageBox.Show("Оберіть вчений ступінь.");
                    return;
                }

                List<string> subjects = txtSubjects.Text.Split(',').Select(s => s.Trim()).ToList();
                List<string> groups = txtGroups.Text.Split(',').Select(s => s.Trim()).ToList();

                EditedTeacher = new ScientificTeacher(
                    lastName, firstName, middleName,
                    articles.ToArray(), reports, patents, degree,
                    subjects, hours, groups, experience
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editStaffForm_Load(object sender, EventArgs e)
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
