using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ScientistManagementSystem_C_
{
    public class ScientificTeacher : Scientist, ICloneable
    {
        public Teacher TeacherInfo { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        // Default constructor
        public ScientificTeacher() : base()
        {
            TeacherInfo = new Teacher();
            LastName = "";
            FirstName = "";
            MiddleName = "";
        }

        // Initialization constructor
        public ScientificTeacher(string lastName, string firstName, string middleName,
                                 Article[] publications, int conferences, int patents, AcademicDegree degree,
                                 Teacher teacherInfo)
            : base(publications, conferences, patents, degree)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            TeacherInfo = new Teacher(teacherInfo); // deep copy
        }

        // Copy constructor
        public ScientificTeacher(ScientificTeacher other) : base(other)
        {
            LastName = other.LastName;
            FirstName = other.FirstName;
            MiddleName = other.MiddleName;
            TeacherInfo = new Teacher(other.TeacherInfo);
        }

        // Clone
        public new object Clone()
        {
            return new ScientificTeacher(this);
        }

        // Destructor
        ~ScientificTeacher()
        {
            // optional
        }

        // Stream input (від TextReader — наприклад, Console.In або File)
        public static ScientificTeacher ReadFrom(TextReader reader)
        {
            string lastName = reader.ReadLine();
            string firstName = reader.ReadLine();
            string middleName = reader.ReadLine();

            var disciplines = reader.ReadLine().Split(',').Select(x => x.Trim()).ToList();
            int workload = int.Parse(reader.ReadLine());
            var groups = reader.ReadLine().Split(',').Select(x => x.Trim()).ToList();
            int experience = int.Parse(reader.ReadLine());

            var teacher = new Teacher(disciplines, workload, groups, experience);

            int pubCount = int.Parse(reader.ReadLine());
            var publications = new Article[pubCount];
            for (int i = 0; i < pubCount; i++)
            {
                var authors = reader.ReadLine().Split(',').Select(x => x.Trim()).ToArray();
                string pubTitle = reader.ReadLine();
                string journal = reader.ReadLine();
                int year = int.Parse(reader.ReadLine());

                publications[i] = new Article(authors, pubTitle, journal, year);
            }

            int conferences = int.Parse(reader.ReadLine());
            int patents = int.Parse(reader.ReadLine());
            AcademicDegree degree = (AcademicDegree)Enum.Parse(typeof(AcademicDegree), reader.ReadLine());

            return new ScientificTeacher(lastName, firstName, middleName, publications, conferences, patents, degree, teacher);
        }

        // Stream output
        public static void WriteTo(TextWriter writer, ScientificTeacher st)
        {
            writer.WriteLine($"Name: {st.LastName} {st.FirstName} {st.MiddleName}");
            writer.WriteLine($"Degree: {st.Degree}");
            writer.WriteLine($"Publications: {st.Publications.Length}");

            foreach (var pub in st.Publications)
            {
                writer.WriteLine(" - " + string.Join(", ", pub.Authors));
                writer.WriteLine("   " + pub.PublicationTitle);
                writer.WriteLine("   " + pub.JournalTitle);
                writer.WriteLine("   " + pub.Year);
            }

            writer.WriteLine($"Conferences: {st.ConferenceCount}");
            writer.WriteLine($"Patents: {st.PatentCount}");

            writer.WriteLine("--- Teaching Info ---");
            Teacher.WriteTo(writer, st.TeacherInfo);
        }

        // ToString override
        public override string ToString()
        {
            return $"Full name: {LastName} {FirstName} {MiddleName}\n" +
                   base.ToString() + "\n\nTeaching info:\n" + TeacherInfo.ToString();
        }



        // Override базового методу
        public override void DisplayInfo()
        {
            Console.WriteLine("=== Scientific Teacher ===");
            Console.WriteLine($"Name: {FirstName} {LastName}");

            // Виклик реалізації базового класу
            base.DisplayInfo(); // ⬅ тут демонстрація "похідний → базовий"
        }

        // Override методу, який викликає базовий
        protected override void CallAdditionalInfo()
        {
            Console.WriteLine("(Derived) Teaching Info:");
            Console.WriteLine($"Disciplines: {string.Join(", ", TeacherInfo.Disciplines)}");
            Console.WriteLine($"Groups: {string.Join(", ", TeacherInfo.Groups)}");
            Console.WriteLine($"Workload: {TeacherInfo.WorkloadHoursPerYear}");
            Console.WriteLine($"Experience: {TeacherInfo.ExperienceYears} years");
        }



       

    }
}
