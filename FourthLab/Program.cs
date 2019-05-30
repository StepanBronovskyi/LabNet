using FourthLab.Classes;
using System;

namespace FourthLab
{
    internal class Program
    {
        #region Properties

        public static TeamsJournal teamsJournal1 { get; set; }
        public static TeamsJournal teamsJournal2 { get; set; }

        #endregion Properties

        #region Methods

        public static void Show_Message(object source, TeamListHandlerEventArgs args)
        {
            TeamsJournalEntry teamsJournalEntry = new TeamsJournalEntry(args.Name, args.TypeOfChange, args.IndexOfElement);

            if (teamsJournalEntry.Name == "researchTeam1")
            {
                teamsJournal1.Journal.Add(teamsJournalEntry);
            }
            teamsJournal2.Journal.Add(teamsJournalEntry);

            Console.WriteLine(args.ToString());
        }

        private static void Main(string[] args)
        {
            ResearchTeamCollection researchTeam1 = new ResearchTeamCollection();
            ResearchTeamCollection researchTeam2 = new ResearchTeamCollection();
            teamsJournal1 = new TeamsJournal();
            teamsJournal2 = new TeamsJournal();

            teamsJournal1.Name = nameof(teamsJournal1);
            teamsJournal2.Name = nameof(teamsJournal2);
            researchTeam1.Name = nameof(researchTeam1);
            researchTeam2.Name = nameof(researchTeam2);

            researchTeam1.ResearchTeamAdded += Show_Message;
            researchTeam1.ResearchTeamInserted += Show_Message;
            researchTeam2.ResearchTeamAdded += Show_Message;
            researchTeam2.ResearchTeamInserted += Show_Message;

            researchTeam1.InsertAt(0, new ResearchTeam());
            researchTeam1.InsertAt(0, new ResearchTeam());
            researchTeam2.InsertAt(0, new ResearchTeam());
            researchTeam2.InsertAt(1, new ResearchTeam());
            researchTeam2.InsertAt(1, new ResearchTeam());
            researchTeam2.InsertAt(3, new ResearchTeam());
            researchTeam2.InsertAt(4, new ResearchTeam());
            researchTeam2.InsertAt(6, new ResearchTeam());

            Console.WriteLine(Environment.NewLine + teamsJournal1.ToString());
            Console.WriteLine(Environment.NewLine + teamsJournal2.ToString());

            Console.ReadKey();
        }

        #endregion Methods
    }
}