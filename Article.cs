using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientistManagementSystem_C_
{
    public class Article
    {
        public string[] Authors { get; set; }
        public string PublicationTitle { get; set; }
        public string JournalTitle { get; set; }
        public int Year { get; set; }

        public Article(string[] authors, string publicationTitle, string journalTitle, int year)
        {
            Authors = authors;
            PublicationTitle = publicationTitle;
            JournalTitle = journalTitle;
            Year = year;
        }

        public Article(Article other)
        {
            Authors = (string[])other.Authors.Clone();
            PublicationTitle = other.PublicationTitle;
            JournalTitle = other.JournalTitle;
            Year = other.Year;
        }
    }
}
