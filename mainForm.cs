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
using System.IO;

namespace ScientistManagementSystem_C_
{
    public partial class mainForm : Form
    {
        private List<ScientificTeacher> scientificTeachers = new List<ScientificTeacher>();
        private ScientificTeacherContainer container = new ScientificTeacherContainer();


        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            cmbStatistics.Items.Clear();
            cmbStatistics.Items.Add("Average Load");
            cmbStatistics.Items.Add("Average Experience");
            cmbStatistics.Items.Add("Find by Subject");
            cmbStatistics.SelectedIndex = 0;
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
        private void проПрограмуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }
       
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            infoStaffForm infoStaffForm = new infoStaffForm();
            infoStaffForm.ShowDialog();
        }

        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void відкритиФайлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadScientificTeachersFromFile(ofd.FileName);
                }
            }
        }

        private void LoadScientificTeachersFromFile(string path)
        {
            try
            {
                scientificTeachers.Clear();
                container = new ScientificTeacherContainer();

                var allText = File.ReadAllText(path);
                var blocks = allText.Split(new[] { "===" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var block in blocks)
                {
                    var lines = block.Trim().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

                    if (lines.Count < 11) continue; // недостатньо рядків

                    string lastName = lines[0];
                    string firstName = lines[1];
                    string middleName = lines[2];

                    List<Article> articles = new List<Article>();
                    int separatorIndex = lines.FindIndex(3, l => l.Trim() == "---");

                    if (separatorIndex == -1) continue;

                    for (int i = 3; i < separatorIndex; i++)
                    {
                        string[] parts = lines[i].Split(';');
                        if (parts.Length != 4) continue;
                        articles.Add(new Article(parts[0], parts[1], parts[2], int.Parse(parts[3])));
                    }

                    int reports = int.Parse(lines[separatorIndex + 1]);
                    int patents = int.Parse(lines[separatorIndex + 2]);
                    if (!Enum.TryParse(lines[separatorIndex + 3], true, out AcademicDegree degree))
                    {
                        MessageBox.Show("Invalid academic degree.");
                        return;
                    }

                    List<string> subjects = lines[separatorIndex + 4].Split(',').Select(s => s.Trim()).ToList();
                    int hours = int.Parse(lines[separatorIndex + 5]);
                    List<string> groups = lines[separatorIndex + 6].Split(',').Select(s => s.Trim()).ToList();
                    int experience = int.Parse(lines[separatorIndex + 7]);

                    var st = new ScientificTeacher(lastName, firstName, middleName,
                        articles.ToArray(), reports, patents, degree,
                        subjects, hours, groups, experience);

                    scientificTeachers.Add(st);
                    container.Add(st);
                }

                LoadScientificTeachersIntoGrid();
                MessageBox.Show("Data successfully loaded.", "Load");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void LoadScientificTeachersIntoGrid()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("FullName", "Full Name");
            dataGridView.Columns.Add("Degree", "Degree");
            dataGridView.Columns.Add("Reports", "Reports");
            dataGridView.Columns.Add("Patents", "Patents");
            dataGridView.Columns.Add("Articles", "Publications");
            dataGridView.Columns.Add("Subjects", "Subjects");
            dataGridView.Columns.Add("Hours", "Annual Hours");
            dataGridView.Columns.Add("Groups", "Groups");
            dataGridView.Columns.Add("Experience", "Experience");

            foreach (var st in scientificTeachers)
            {
                dataGridView.Rows.Add(
                    $"{st.LastName} {st.FirstName} {st.MiddleName}",
                    st.Degree.ToString(),
                    st.ConferenceReports,
                    st.Patents,
                    st.Publications.Length,
                    string.Join(", ", st.TeacherData.Subjects),
                    st.TeacherData.AnnualHours,
                    string.Join(", ", st.TeacherData.Groups),
                    st.TeacherData.ExperienceYears
                );
            }
        }

        private void зберегтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text files (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveScientificTeachersToFile(sfd.FileName);
                }
            }
        }

        private void SaveScientificTeachersToFile(string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var st in scientificTeachers)
                    {
                        writer.WriteLine(st.LastName);
                        writer.WriteLine(st.FirstName);
                        writer.WriteLine(st.MiddleName);

                        foreach (var article in st.Publications)
                        {
                            writer.WriteLine($"{article.Authors};{article.JournalName};{article.Title};{article.Year}");
                        }

                        writer.WriteLine("---"); // роздільник між публікаціями та рештою

                        writer.WriteLine(st.ConferenceReports);
                        writer.WriteLine(st.Patents);
                        writer.WriteLine(st.Degree.ToString());

                        writer.WriteLine(string.Join(",", st.TeacherData.Subjects));
                        writer.WriteLine(st.TeacherData.AnnualHours);
                        writer.WriteLine(string.Join(",", st.TeacherData.Groups));
                        writer.WriteLine(st.TeacherData.ExperienceYears);

                        writer.WriteLine("==="); // роздільник між об'єктами
                    }
                }

                MessageBox.Show("Data successfully saved.", "Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }


        private void btnTestPolymorphism_Click(object sender, EventArgs e)
        {
            // Scientist (базовий)
            Scientist baseScientist = new Scientist(
                new Article[]
                {
            new Article("Petrov", "Science Journal", "NanoTech", 2020)
                },
                3, 1, AcademicDegree.PhD
            );

            // ScientificTeacher (похідний, але вказівник на базовий)
            Scientist derivedScientist = new ScientificTeacher(
                "Ivanov", "Oleh", "Petrovych",
                new Article[]
                {
            new Article("Ivanov", "AI Journal", "Machine Learning", 2022)
                },
                2, 2, AcademicDegree.DoctorTechnical,
                new List<string> { "AI", "ML" },
                620,
                new List<string> { "Group1", "Group2" },
                12
            );

            // Вивід — демонстрація пізнього зв’язування
            MessageBox.Show(baseScientist.Display(), "Base Object Call");
            MessageBox.Show(derivedScientist.Display(), "Derived Object Call via Base Reference");
        }

        

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            if (cmbStatistics.SelectedItem == null)
            {
                MessageBox.Show("Please select a statistic type.");
                return;
            }

            string selected = cmbStatistics.SelectedItem.ToString();

            switch (selected)
            {
                case "Average Load":
                    double avgLoad = container.GetAverageLoad();
                    MessageBox.Show($"Average Load: {avgLoad:F1} hours", "Statistics");
                    break;

                case "Average Experience":
                    double avgExp = container.GetAverageExperience();
                    MessageBox.Show($"Average Experience: {avgExp:F1} years", "Statistics");
                    break;

                case "Find by Subject":
                    string subject = PromptInput("Enter subject to search:", "Subject Filter");
                    if (!string.IsNullOrWhiteSpace(subject))
                    {
                        ShowTeachersBySubject(subject.Trim());
                    }
                    break;

                default:
                    MessageBox.Show("Unknown option.");
                    break;
            }
        }

        private void ShowTeachersBySubject(string subject)
        {
            var filtered = container.GetTeachersBySubject(subject);
            if (filtered.Count == 0)
            {
                MessageBox.Show("No teachers found for this subject.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var t in filtered)
            {
                sb.AppendLine(t.Display());
                sb.AppendLine("-------------------------");
            }

            MessageBox.Show(sb.ToString(), $"Teachers for: {subject}");
        }


        private string PromptInput(string message, string title)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = message, Width = 340 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }        
    }
}
