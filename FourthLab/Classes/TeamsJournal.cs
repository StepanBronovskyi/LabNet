using FourthLab.Classes;
using System.Collections.Generic;
using System.Text;

namespace FourthLab
{
    public class TeamsJournal
    {
        #region Constructors

        public TeamsJournal() : this(journal: new List<TeamsJournalEntry>())
        {
        }

        public TeamsJournal(List<TeamsJournalEntry> journal)
        {
            Journal = journal;
        }

        #endregion Constructors

        #region Events

        public event ResearchTeamCollection.TeamListHandler ResearchTeamAdded;

        public event ResearchTeamCollection.TeamListHandler ResearchTeamInserted;

        #endregion Events

        #region Properties

        public string Name { get; set; }
        public List<TeamsJournalEntry> Journal { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Journal: " + Name);
            foreach (var entry in Journal)
            {
                stringBuilder.Append(entry);
            }

            return stringBuilder.ToString();
        }

        #endregion Methods
    }
}