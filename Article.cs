using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    [Serializable]
    public class Article
    {
        public string Authors { get; set; }
        public string JournalName { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Article(string authors, string journalName, string title, int year)
        {
            Authors = authors;
            JournalName = journalName;
            Title = title;
            Year = year;
        }

        public Article(Article other)
        {
            Authors = other.Authors;
            JournalName = other.JournalName;
            Title = other.Title;
            Year = other.Year;
        }

        public Article() { }
    }
}
