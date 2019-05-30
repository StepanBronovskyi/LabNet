using FirstLab.Classes;
using FirstLab.Enums;
using System;

namespace FirstLab
{
    internal class Program
    {
        #region Methods

        private static void TestTimeInDiffTypeOfArray()
        {
            Console.WriteLine("Enter count of row and count of column(split it by , or whitespace):");
            string[] informationFromUser = Console.ReadLine().Split(' ', ',');
            if ((informationFromUser == null || informationFromUser.Length < 2))
            {
                return;
            }
            int.TryParse(informationFromUser[0], out int countRows);
            int.TryParse(informationFromUser[1], out int countColumn);

            Paper[] oneDemensionalArray = new Paper[countColumn * countRows];
            for (int i = 0; i < oneDemensionalArray.Length; i++)
            {
                oneDemensionalArray[i] = new Paper();
            }

            Paper[,] twoDemensionalArray = new Paper[countRows, countColumn];
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumn; j++)
                {
                    twoDemensionalArray[i, j] = new Paper();
                }
            }

            Paper[][] firstJaggedArray = new Paper[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                firstJaggedArray[i] = new Paper[countColumn];
                for (int j = 0; j < countColumn; j++)
                {
                    firstJaggedArray[i][j] = new Paper();
                }
            }

            Paper[][] secondJaggedArray = new Paper[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                secondJaggedArray[i] = new Paper[i];
                for (int j = 0; j < i; j++)
                {
                    secondJaggedArray[i][j] = new Paper();
                }
            }

            var startTime = Environment.TickCount;
            foreach (var item in oneDemensionalArray)
            {
                item.NameOfPublish = "test name";
            }
            Console.WriteLine(Environment.TickCount - startTime);

            startTime = Environment.TickCount;
            foreach (var item in twoDemensionalArray)
            {
                item.NameOfPublish = "test name";
            }
            Console.WriteLine(Environment.TickCount - startTime);

            startTime = Environment.TickCount;
            foreach (var item in firstJaggedArray)
            {
                foreach (var paper in item)
                {
                    paper.NameOfPublish = "test name";
                }
            }
            Console.WriteLine(Environment.TickCount - startTime);

            startTime = Environment.TickCount;
            foreach (var item in secondJaggedArray)
            {
                foreach (var paper in item)
                {
                    paper.NameOfPublish = "test name";
                }
            }
            Console.WriteLine(Environment.TickCount - startTime);
        }

        private static void Main(string[] args)
        {
            Person tempPerson = new Person("some", "one", new DateTime(1999, 01, 01));
            Person tempPerson2 = new Person("second", "one", new DateTime(1997, 01, 01));
            Paper[] tempPapers = new Paper[2]{ new Paper("somePublish", tempPerson, new DateTime(2000, 01, 01)),
                new Paper("somePublishElse", tempPerson2, new DateTime(2003, 01, 01))};
            Paper[] tempPapersForAddPapers = new Paper[2]{ new Paper("publish for test addPapers", tempPerson, new DateTime(2000, 01, 01)),
                new Paper(" anouther publish for test addPapers", tempPerson2, new DateTime(2003, 01, 01))};

            ResearchTeam researchTeam = new ResearchTeam("testStudyName",
                "testNameOfOrganization", 0, TimeFrame.TwoYears, tempPapers); ;

            //first point
            Console.WriteLine(researchTeam.ToShortString());

            //second point
            Console.WriteLine(researchTeam[TimeFrame.Long]);
            //only this is true
            Console.WriteLine(researchTeam[TimeFrame.TwoYears]);
            Console.WriteLine(researchTeam[TimeFrame.Year]);

            //third point
            researchTeam.RegistrationNumber = 2;
            Console.WriteLine(researchTeam.ToString());

            //fourth point
            researchTeam.AddPapers(tempPapersForAddPapers);
            Console.WriteLine(researchTeam.ToString());

            TestTimeInDiffTypeOfArray();

            Console.ReadKey();
        }

        #endregion Methods
    }
}