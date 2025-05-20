using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;

namespace ScientistManagementSystem_C_
{
    public class ScientificTeacherContainer : IEnumerable<ScientificTeacher>
    {
        private List<ScientificTeacher> teachers;

        public ScientificTeacherContainer()
        {
            teachers = new List<ScientificTeacher>();
        }

        public void Add(ScientificTeacher teacher)
        {
            teachers.Add(teacher);
        }

        public void Remove(ScientificTeacher teacher)
        {
            teachers.Remove(teacher);
        }

        public int Count => teachers.Count;

        public ScientificTeacher this[int index]
        {
            get => teachers[index];
            set => teachers[index] = value;
        }

        public void DisplayAll()
        {
            foreach (var t in teachers)
            {
                t.DisplayInfo();
                Console.WriteLine("-----------------------------");
            }
        }

        // ✅ Статистика — середнє навантаження
        public double GetAverageWorkload()
        {
            return teachers.Average(t => t.TeacherInfo.WorkloadHoursPerYear);
        }

        // ✅ Статистика — середній стаж
        public double GetAverageExperience()
        {
            return teachers.Average(t => t.TeacherInfo.ExperienceYears);
        }

        // ✅ Список працівників, що викладають певну дисципліну
        public List<ScientificTeacher> GetTeachersByDiscipline(string discipline)
        {
            return teachers
                .Where(t => t.TeacherInfo.Disciplines.Contains(discipline, StringComparer.OrdinalIgnoreCase))
                .ToList();
        }

        // ✅ Ітератор (реалізація інтерфейсу IEnumerable)
        public IEnumerator<ScientificTeacher> GetEnumerator()
        {
            foreach (var teacher in teachers)
            {
                yield return teacher;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(teachers, options);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };

            string json = File.ReadAllText(filePath);
            teachers = JsonSerializer.Deserialize<List<ScientificTeacher>>(json, options)
                       ?? new List<ScientificTeacher>();
        }


    }
}


