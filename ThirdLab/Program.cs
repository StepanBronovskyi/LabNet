using System;
using System.Collections.Generic;
using System.Linq;
using ThirdLab.Classes;

namespace ThirdLab
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            Person[] members = new Person[] { new Person("first" + 3, "last" + 3, new DateTime(3 + 1970, 3 % 12, 3 % 27)),
                new Person("first" + 2, "last" + 2, new DateTime(2 + 1970, 2 % 12, 2 % 27)),
                new Person("first" + 1, "last" + 1, new DateTime(1 + 1970, 1 % 12, 1 % 27))};
            ResearchTeamCollection researchTeamCollection = new ResearchTeamCollection();
            ResearchTeam[] researchTeams = new ResearchTeam[]
            {
                new ResearchTeam("name" + 3, "study" + 3, 3 + 1, Enums.TimeFrame.Year,
                new List<Paper> { new Paper("some" + 3, new Person("first" + 1, "last" + 1, new DateTime(3 + 1970, 3 % 12, 3 % 27)),
                new DateTime(3 + 1970, 3 % 12, 3 % 27)) }),
                new ResearchTeam("name" + 1, "study" + 1, 1 + 1, Enums.TimeFrame.TwoYears,
                new List<Paper> { new Paper("some" + 1, new Person("first" + 1, "last" + 1, new DateTime(1 + 1970, 1 % 12, 1 % 27)),
                new DateTime(1 + 1970, 1 % 12, 1 % 27)) }),
                new ResearchTeam("name" + 50, "study" + 50, 50 + 1, Enums.TimeFrame.Year,
                new List<Paper> { new Paper("some" + 50, new Person("first" + 1, "last" + 1, new DateTime(50 + 1970, 50 % 12, 50 % 27)),
                new DateTime(50 + 1970, 50 % 12, 50 % 27)) }),
                new ResearchTeam("name" + 21, "study" + 21, 21 + 1, Enums.TimeFrame.Year,
                new List<Paper> { new Paper("some" + 21, new Person("first" + 1, "last" + 1, new DateTime(21 + 1970, 21 % 12, 21 % 27)),
                new DateTime(21 + 1970, 21 % 12, 21 % 27)) })
            };
            researchTeams[0].Members = members.Skip(2).ToList();
            researchTeams[1].Members = members.Skip(1).ToList();
            researchTeams[2].Members = members.ToList();
            researchTeamCollection.AddResearchTeams(researchTeams);
            Console.WriteLine(researchTeamCollection.ToString());

            researchTeamCollection.SortByRegistrationNumber();
            Console.WriteLine(researchTeamCollection.ToString());

            researchTeamCollection.SortByExploreTheme();
            Console.WriteLine(researchTeamCollection.ToString());

            researchTeamCollection.SortByCountOfPublishing();
            Console.WriteLine(researchTeamCollection.ToString());

            Console.WriteLine(researchTeamCollection.MinRegistryNumber);

            var str = string.Join(Environment.NewLine, researchTeamCollection.GetTwoYearsLongResearchTeams.Select(x => x.ToString()));
            Console.WriteLine(str);

            str = string.Join(Environment.NewLine, researchTeamCollection.NGroup(1).Select(x => x.ToString()));
            Console.WriteLine(str);

            TestCollections testCollections = new TestCollections(2000000);
            testCollections.TestCollectionsProductivity(1);
            testCollections.TestCollectionsProductivity(1000001);
            testCollections.TestCollectionsProductivity(1999999);
            testCollections.TestCollectionsProductivity(20000001);

            Console.ReadKey();
        }

        #endregion Methods
    }
}