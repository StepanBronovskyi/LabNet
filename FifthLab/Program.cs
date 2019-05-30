using FifthLab.Classes;
using System;
using System.Collections.Generic;

namespace FifthLab
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            ResearchTeam researchTeam = new ResearchTeam("name" + 3, "study" + 3, 3 + 1, Enums.TimeFrame.Year,
                new List<Paper> { new Paper("some" + 3, new Person("first" + 1, "last" + 1, new DateTime(3 + 1970, 3 % 12, 3 % 27)),
                new DateTime(3 + 1970, 3 % 12, 3 % 27)) });
            Paper paper = new Paper("some" + 3, new Person("first" + 1, "last" + 1, new DateTime(3 + 1970, 3 % 12, 3 % 27)), new DateTime(3 + 1970, 3 % 12, 3 % 27));
            Person person = new Person("PERSON", "SURNAME", new DateTime(2018, 11, 12));

            researchTeam.AddMembers(person);
            researchTeam.AddMembers(person);
            researchTeam.AddPapers(paper);

            var deepCopy = ResearchTeam.DeepCopy<ResearchTeam>(researchTeam);

            researchTeam.NameOfStudy = "a";
            Console.WriteLine(researchTeam.NameOfStudy);
            Console.WriteLine(deepCopy.NameOfStudy);

            if (researchTeam.Save("TEST"))
            {
                Console.WriteLine("File is Saved");
            }
            ResearchTeam loadedObject = new ResearchTeam();
            if (loadedObject.Load("TEST"))
            {
                Console.WriteLine("File is Readed");
            }

            ResearchTeam researchTeamStatic = new ResearchTeam();
            ResearchTeam.Load("TEST", researchTeamStatic);
            Console.WriteLine(researchTeamStatic);
            ResearchTeam.Save("TEST2", deepCopy);

            researchTeam.AddPaperFromConsole();
            researchTeam.Save("TEST2");
        }

        #endregion Methods
    }
}