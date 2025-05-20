using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    public class Teacher : ICloneable
    {
        public List<string> Disciplines { get; set; }
        public int WorkloadHoursPerYear { get; set; }
        public List<string> Groups { get; set; }
        public int ExperienceYears { get; set; }

        // Default constructor
        public Teacher()
        {
            Disciplines = new List<string>();
            Groups = new List<string>();
            WorkloadHoursPerYear = 0;
            ExperienceYears = 0;
        }

        // Initialization constructor
        public Teacher(List<string> disciplines, int workload, List<string> groups, int experience)
        {
            Disciplines = new List<string>(disciplines);
            WorkloadHoursPerYear = workload;
            Groups = new List<string>(groups);
            ExperienceYears = experience;
        }

        // Copy constructor
        public Teacher(Teacher other)
        {
            Disciplines = new List<string>(other.Disciplines);
            WorkloadHoursPerYear = other.WorkloadHoursPerYear;
            Groups = new List<string>(other.Groups);
            ExperienceYears = other.ExperienceYears;
        }

        // Clone method
        public object Clone()
        {
            return new Teacher(this);
        }

        // Destructor
        ~Teacher()
        {
            // No unmanaged resources used here
        }

        // () operator overload — assign values interactively
        public void SetValues(List<string> disciplines, int workload, List<string> groups, int experience)
        {
            Disciplines = new List<string>(disciplines);
            WorkloadHoursPerYear = workload;
            Groups = new List<string>(groups);
            ExperienceYears = experience;
        }

        // Assignment (already handled naturally by C#, unless you need deep copy)
        public void CopyFrom(Teacher other)
        {
            if (other == null) return;

            Disciplines = new List<string>(other.Disciplines);
            Groups = new List<string>(other.Groups);
            WorkloadHoursPerYear = other.WorkloadHoursPerYear;
            ExperienceYears = other.ExperienceYears;
        }

        // Stream input (text input emulation)
        public static Teacher ReadFrom(TextReader reader)
        {
            var disciplines = reader.ReadLine().Split(',').Select(s => s.Trim()).ToList();
            int workload = int.Parse(reader.ReadLine());
            var groups = reader.ReadLine().Split(',').Select(s => s.Trim()).ToList();
            int experience = int.Parse(reader.ReadLine());

            return new Teacher(disciplines, workload, groups, experience);
        }

        // Stream output
        public static void WriteTo(TextWriter writer, Teacher t)
        {
            writer.WriteLine("Disciplines: " + string.Join(", ", t.Disciplines));
            writer.WriteLine("Workload (hours/year): " + t.WorkloadHoursPerYear);
            writer.WriteLine("Groups: " + string.Join(", ", t.Groups));
            writer.WriteLine("Experience (years): " + t.ExperienceYears);
        }

        // ToString override
        public override string ToString()
        {
            return $"Disciplines: {string.Join(", ", Disciplines)}\n" +
                   $"Workload: {WorkloadHoursPerYear} hours/year\n" +
                   $"Groups: {string.Join(", ", Groups)}\n" +
                   $"Experience: {ExperienceYears} years";
        }
    }
}
