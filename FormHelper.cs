using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientistManagementSystem_C_
{
    public static class FormHelper
    {
        public static List<ScientificTeacher> LoadFromFile(string path)
        {
            List<ScientificTeacher> list = new List<ScientificTeacher>();

            var allText = File.ReadAllText(path);
            var blocks = allText.Split(new[] { "===" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var block in blocks)
            {
                var lines = block.Trim().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

                if (lines.Count < 11) continue;

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
                    continue;

                List<string> subjects = lines[separatorIndex + 4].Split(',').Select(s => s.Trim()).ToList();
                int hours = int.Parse(lines[separatorIndex + 5]);
                List<string> groups = lines[separatorIndex + 6].Split(',').Select(s => s.Trim()).ToList();
                int experience = int.Parse(lines[separatorIndex + 7]);

                var st = new ScientificTeacher(lastName, firstName, middleName,
                    articles.ToArray(), reports, patents, degree,
                    subjects, hours, groups, experience);

                list.Add(st);
            }

            return list;
        }

        public static void ApplyDataGridStyle(DataGridView dataGridView)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.LightGray;
            headerStyle.Font = new Font("Arsenal", 10F, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.Font = new Font("Arsenal", 11F, FontStyle.Regular);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }


        public static void SaveToFile(string path, List<ScientificTeacher> teachers)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var st in teachers)
                {
                    writer.WriteLine(st.LastName);
                    writer.WriteLine(st.FirstName);
                    writer.WriteLine(st.MiddleName);

                    foreach (var article in st.Publications)
                    {
                        writer.WriteLine($"{article.Authors};{article.JournalName};{article.Title};{article.Year}");
                    }

                    writer.WriteLine("---");

                    writer.WriteLine(st.ConferenceReports);
                    writer.WriteLine(st.Patents);
                    writer.WriteLine(st.Degree.ToString());

                    writer.WriteLine(string.Join(",", st.TeacherData.Subjects));
                    writer.WriteLine(st.TeacherData.AnnualHours);
                    writer.WriteLine(string.Join(",", st.TeacherData.Groups));
                    writer.WriteLine(st.TeacherData.ExperienceYears);

                    writer.WriteLine("===");
                }
            }
        }


        public static string PromptInput(string message, string title)
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
