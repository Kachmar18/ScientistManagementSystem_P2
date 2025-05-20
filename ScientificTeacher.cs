using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    public class ScientificTeacher : Scientist
    {
        public Teacher TeacherData { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        // Constructor
        public ScientificTeacher(string lastName, string firstName, string middleName,
            Article[] publications, int reports, int patents, AcademicDegree degree,
            List<string> subjects, int hours, List<string> groups, int experienceYears)
            : base(publications, reports, patents, degree)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            TeacherData = new Teacher(subjects, hours, groups, experienceYears);
        }

        // Copy constructor
        public ScientificTeacher(ScientificTeacher other)
            : base(other)
        {
            TeacherData = new Teacher(other.TeacherData);
            LastName = other.LastName;
            FirstName = other.FirstName;
            MiddleName = other.MiddleName;
        }

        // Destructor
        ~ScientificTeacher()
        {
            // Optional clean-up
        }

        // Output
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}\n{base.ToString()}\n{TeacherData.ToString()}";
        }

        // Input parser (example: from one formatted line)
        public static ScientificTeacher Parse(string[] lines)
        {
            // Реалізація залежить від формату вхідних даних — можу допомогти при потребі
            throw new NotImplementedException();
        }

        // Additional setter
        public void SetPersonalData(string last, string first, string middle)
        {
            LastName = last;
            FirstName = first;
            MiddleName = middle;
        }




        public override string Display()
        {
            return $"[ScientificTeacher] {LastName} {FirstName} {MiddleName}\n" +
                   base.Display() + "\n" +
                   $"Subjects: {string.Join(", ", TeacherData.Subjects)}, Hours: {TeacherData.AnnualHours}, " +
                   $"Groups: {string.Join(", ", TeacherData.Groups)}, Experience: {TeacherData.ExperienceYears}";
        }
    }
}
