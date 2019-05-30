using SecondLab.Classes;
using System;

namespace SecondLab
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            Team firstTeam = new Team("First team", 1234256);
            Team secondTeam = new Team("First team", 1234256);

            if (!ReferenceEquals(firstTeam, secondTeam) && firstTeam.Equals(secondTeam))
            {
                Console.WriteLine($"{nameof(firstTeam)} has HASHCODE: {firstTeam.GetHashCode()}");
                Console.WriteLine($"{nameof(secondTeam)} has HASHCODE: {secondTeam.GetHashCode()}");
            }

            try
            {
                Team incorrectValue = new Team("First team", -14254);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot create team because {ex.Message} instead of -14254");
            }

            Person[] members = new Person[] { new Person("some", "one", new DateTime(1998, 12, 12)), new Person("some", "one else", new DateTime(1998, 12, 13)) };
            ResearchTeam researchTeam = new ResearchTeam("First research team", "who know", 1454, Enums.TimeFrame.Long,
                    new Paper[] { new Paper("some publish", members[1], new DateTime(2018, 12, 12)), new Paper("some publish else", members[1], new DateTime(2012, 12, 12)) });
            researchTeam.Members = members;
            Console.WriteLine(researchTeam.Team.ToString());

            ResearchTeam secondResearchTeam = researchTeam.DeepCopy() as ResearchTeam;
            researchTeam.DurationOfResearch = Enums.TimeFrame.Year;

            Console.WriteLine(researchTeam.ToString());
            Console.WriteLine(secondResearchTeam.ToString());

            foreach (Person member in researchTeam.GetMembersWithoutAnyPublish())
            {
                Console.WriteLine(member.ToString());
            }

            foreach (Paper paper in researchTeam.GetPublishingInRecentYear(2))
            {
                Console.WriteLine(paper.ToString());
            }

            Console.ReadKey();
        }

        #endregion Methods
    }
}