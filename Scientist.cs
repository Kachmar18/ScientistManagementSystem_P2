using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    public class Scientist
    {
        public Article[] Publications { get; set; }
        public int ConferenceReports { get; set; }
        public int Patents { get; set; }
        public AcademicDegree Degree { get; set; }

        // Constructor
        public Scientist(Article[] publications, int conferenceReports, int patents, AcademicDegree degree)
        {
            Publications = publications;
            ConferenceReports = conferenceReports;
            Patents = patents;
            Degree = degree;
        }

        // Copy constructor
        public Scientist(Scientist other)
        {
            Publications = other.Publications.Select(a => new Article(a)).ToArray();
            ConferenceReports = other.ConferenceReports;
            Patents = other.Patents;
            Degree = other.Degree;
        }

        // Destructor
        ~Scientist()
        {
            // Clean-up if needed (not commonly used in .NET)
        }

        // Access methods
        public void SetDegree(AcademicDegree degree) => Degree = degree;
        public AcademicDegree GetDegree() => Degree;

        public void SetPublications(Article[] articles) => Publications = articles;
        public Article[] GetPublications() => Publications;

        public void SetConferenceReports(int count) => ConferenceReports = count;
        public int GetConferenceReports() => ConferenceReports;

        public void SetPatents(int count) => Patents = count;
        public int GetPatents() => Patents;




        public void SetAll(Article[] publications, int reports, int patents, AcademicDegree degree)
        {
            Publications = publications;
            ConferenceReports = reports;
            Patents = patents;
            Degree = degree;
        }

        // Імітація присвоєння
        public void CopyFrom(Scientist other)
        {
            Publications = other.Publications.Select(a => new Article(a)).ToArray();
            ConferenceReports = other.ConferenceReports;
            Patents = other.Patents;
            Degree = other.Degree;
        }

        // Імітація "переміщення"
        public static Scientist Move(ref Scientist other)
        {
            Scientist moved = new Scientist(other.Publications, other.ConferenceReports, other.Patents, other.Degree);
            other.Publications = null;
            other.ConferenceReports = 0;
            other.Patents = 0;
            other.Degree = AcademicDegree.None;
            return moved;
        }

        // Вивід
        public override string ToString()
        {
            return $"Degree: {Degree}, Reports: {ConferenceReports}, Patents: {Patents}, Publications: {Publications.Length}";
        }

        // Зчитування з рядка
        public static Scientist Parse(string data)
        {
            // TODO: реалізація при потребі
            throw new NotImplementedException();
        }




        public virtual string Display()
        {
            return $"[Scientist] Degree: {Degree}, Reports: {ConferenceReports}, Patents: {Patents}, Publications: {Publications.Length}";
        }

    }
}
