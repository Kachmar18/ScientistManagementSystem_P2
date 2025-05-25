﻿using System;
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
using System.Security.Cryptography;

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
            cmbStatistics.Items.Add("Середнє навантаження");
            cmbStatistics.Items.Add("Середній стаж роботи");
            cmbStatistics.Items.Add("Пошук за дисципліною");
            cmbStatistics.SelectedIndex = 0;
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void відкритиФайлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML files (*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    scientificTeachers = FormHelper.LoadFromXml(ofd.FileName);
                    container = new ScientificTeacherContainer();
                    container.AddRange(scientificTeachers);
                    LoadScientificTeachersIntoGrid();
                    MessageBox.Show("Дані успішно завантажено з XML.", "Завантаження");
                }
            }


        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML files (*.xml)|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FormHelper.SaveToXml(sfd.FileName, scientificTeachers);
                    MessageBox.Show("Дані успішно збережено у XML.", "Збереження");
                }
            }

        } 



        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            if (cmbStatistics.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть тип статистики.");
                return;
            }

            string selected = cmbStatistics.SelectedItem.ToString();

            switch (selected)
            {
                case "Середнє навантаження":
                    double avgLoad = container.GetAverageLoad();
                    MessageBox.Show($"Середнє навантаження: {avgLoad:F1} годин", "Статистика");
                    break;

                case "Середній стаж роботи":
                    double avgExp = container.GetAverageExperience();
                    MessageBox.Show($"Середній стаж роботи: {avgExp:F1} років", "Статистика");
                    break;

                case "Пошук за дисципліною":
                    string subject = FormHelper.PromptInput("Введіть назву предмету для пошуку:", "Фільтр для предметів");
                    if (!string.IsNullOrWhiteSpace(subject))
                    {
                        ShowTeachersBySubject(subject.Trim());
                    }
                    break;

                default:
                    MessageBox.Show("Невідомий варіант");
                    break;
            }
        }

        private void ShowTeachersBySubject(string subject)
        {
            var filtered = container.GetTeachersBySubject(subject);
            if (filtered.Count == 0)
            {
                MessageBox.Show("Не знайдено жодного викладача для цього предмету.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var t in filtered)
            {
                sb.AppendLine(t.Display());
                sb.AppendLine("-------------------------");
            }

            MessageBox.Show(sb.ToString(), $"Викладачі, що викладають: {subject}");
        }

               

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            addStaffForm form = new addStaffForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newTeacher = form.NewTeacher;
                if (newTeacher != null)
                {
                    scientificTeachers.Add(newTeacher);
                    container.Add(newTeacher);
                    LoadScientificTeachersIntoGrid();
                }
            }
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, оберіть рядок для редагування.");
                return;
            }

            int rowIndex = dataGridView.SelectedRows[0].Index;

            if (rowIndex >= 0 && rowIndex < scientificTeachers.Count)
            {
                var teacherToEdit = scientificTeachers[rowIndex];
                editStaffForm form = new editStaffForm();

                form.LoadTeacherForEdit(teacherToEdit);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updatedTeacher = form.EditedTeacher;

                    if (updatedTeacher != null)
                    {
                        scientificTeachers[rowIndex] = updatedTeacher;

                        container = new ScientificTeacherContainer();
                        container.AddRange(scientificTeachers);

                        LoadScientificTeachersIntoGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Помилка: обраний рядок не відповідає запису у списку.");
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, оберіть рядок для видалення.");
                return;
            }

            int rowIndex = dataGridView.SelectedRows[0].Index;

            if (rowIndex >= 0 && rowIndex < scientificTeachers.Count)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цього працівника?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    scientificTeachers.RemoveAt(rowIndex);

                    container = new ScientificTeacherContainer();
                    container.AddRange(scientificTeachers);

                    LoadScientificTeachersIntoGrid();
                }
            }
            else
            {
                MessageBox.Show("Помилка: обраний рядок не відповідає запису у списку.");
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

            MessageBox.Show(baseScientist.Display(), "Виклик базового об'єкта");
            MessageBox.Show(derivedScientist.Display(), "Виклик похідного об'єкту через базове посилання");
        }

        private void btnCleanDataGried_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Ви впевнені, що хочете очистити всі дані?", "Підтвердження", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                scientificTeachers.Clear();
                container = new ScientificTeacherContainer();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
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

            // 🔽 Налаштування стилю
            FormHelper.ApplyDataGridStyle(dataGridView);
        }
    }
}
