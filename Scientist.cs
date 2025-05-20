using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    public class Scientist : ICloneable, IComparable<Scientist>
    {
        public Article[] Publications { get; set; }
        public int ConferenceCount { get; set; }
        public int PatentCount { get; set; }
        public AcademicDegree Degree { get; set; }

        public Scientist(Article[] publications, int conferenceCount, int patentCount, AcademicDegree degree)
        {
            Publications = publications;
            ConferenceCount = conferenceCount;
            PatentCount = patentCount;
            Degree = degree;
        }


        public Scientist()
        {
            Publications = new Article[0];
            ConferenceCount = 0;
            PatentCount = 0;
            Degree = AcademicDegree.None;
        }


        // Copy constructor
        public Scientist(Scientist other)
        {
            Publications = other.Publications.Select(p => new Article(p)).ToArray();
            ConferenceCount = other.ConferenceCount;
            PatentCount = other.PatentCount;
            Degree = other.Degree;
        }

        // ICloneable implementation
        public object Clone()
        {
            return new Scientist(this);
        }

        // IComparable implementation (наприклад, по кількості публікацій)
        public int CompareTo(Scientist other)
        {
            return this.Publications.Length.CompareTo(other.Publications.Length);
        }

        // Destructor
        ~Scientist()
        {
            // В реальному житті — для unmanaged ресурсів
        }


        public virtual void DisplayInfo()
        {
            Console.WriteLine("=== Scientist Info ===");
            Console.WriteLine($"Degree: {Degree}");
            Console.WriteLine($"Publications: {Publications.Length}");
            Console.WriteLine($"Conferences: {ConferenceCount}");
            Console.WriteLine($"Patents: {PatentCount}");

            // ІМІТАЦІЯ: "виклик похідного з базового" — simulate virtual dispatch
            CallAdditionalInfo();
        }

        // Метод, який може бути перевизначений похідним класом
        protected virtual void CallAdditionalInfo()
        {
            Console.WriteLine("(Base) No additional info.");
        }

    }
}
