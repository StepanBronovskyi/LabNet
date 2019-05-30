using System;
using System.Collections.Generic;

namespace FifthLab.Classes
{
    public class TestCollections
    {
        #region Fields

        private List<Team> _teams;
        private List<string> _list;
        private Dictionary<Team, ResearchTeam> _tDictionary;
        private Dictionary<string, ResearchTeam> _sDictionary;

        #endregion Fields

        #region Constructors

        public TestCollections(int count)
        {
            _teams = new List<Team>();
            _list = new List<string>();
            _tDictionary = new Dictionary<Team, ResearchTeam>();
            _sDictionary = new Dictionary<string, ResearchTeam>();
            for (int i = 0; i < count; i++)
            {
                ResearchTeam researchTeam = CreateResearchTeam(i);
                Team team = CreateTeam(i);
                _teams.Add(team);
                _list.Add(team.ToString());
                _tDictionary.Add(team, researchTeam);
                _sDictionary.Add(team.ToString(), researchTeam);
            }
        }

        #endregion Constructors

        #region Methods

        public static ResearchTeam CreateResearchTeam(int index)
        {
            var researchTeam = new ResearchTeam("name" + index, "study" + index, index + 1, Enums.TimeFrame.Year,
                new List<Paper> { new Paper("some" + index, new Person("first" + 1, "last" + 1, new DateTime(index%2000 + 1970, index % 11 +1, index % 27 +1)),
                new DateTime(index%2000 + 1970, index % 11 +1, index % 27 +1)) });
            return researchTeam;
        }

        public static Team CreateTeam(int index)
        {
            return new Team("Name" + index, index + 1);
        }

        public void TestCollectionsProductivity(int index)
        {
            Team suggestedTeam = CreateTeam(index);
            ResearchTeam suggestedResearchTeam = CreateResearchTeam(index);

            var start = Environment.TickCount;
            if (_teams.Contains(suggestedTeam))
                Console.WriteLine("Teams contain suggested team");
            var end = Environment.TickCount;
            Console.WriteLine("Suggested team in Teams: " + (end - start));

            start = Environment.TickCount;

            if (_list.Contains(suggestedTeam.ToString()))
                Console.WriteLine("StringList contain suggested team");

            end = Environment.TickCount;
            Console.WriteLine("Suggested team in string list: " + (end - start));

            start = Environment.TickCount;
            if (_tDictionary.ContainsKey(suggestedTeam))
                if (suggestedResearchTeam.Equals(_tDictionary[suggestedTeam]))
                    Console.WriteLine("TeamDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key): " + (end - start));

            start = Environment.TickCount;

            if (_sDictionary.ContainsKey(suggestedTeam.ToString()))
                if (suggestedResearchTeam.Equals(_sDictionary[suggestedTeam.ToString()]))
                    Console.WriteLine("StringDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key): " + (end - start));
        }

        #endregion Methods
    }
}