using System;
using System.IO;
using System.Text;
using System.Threading;

namespace SeventhLab
{
    internal class Program
    {
        #region Properties

        public static StringBuilder Result { get; set; } = new StringBuilder();

        #endregion Properties

        #region Methods

        public static void GetCountRepeatsInFile(object x)
        {
            int countPerform = 0;
            int countRepeats = 0;
            Values values = (Values)x;
            using (StreamReader sr = values.File.OpenText())
            {
                string readLine = "";
                int length = sr.ReadToEnd().Split('\n').Length;
                sr.BaseStream.Position = 0;
                while ((readLine = sr.ReadLine()) != null)
                {
                    if (readLine == values.SearchString)
                        ++countRepeats;
                    Console.WriteLine(values.File.Name + " perform " + (++countPerform * 100) / length + " %");
                }
            }
            Result.Append(values.File.Name + " " + values.SearchString + " repeats " + countRepeats + " times\n");
            Thread.Sleep(400);
        }

        private static void Main(string[] args)
        {
            Values values = new Values();
            DirectoryInfo directory = new DirectoryInfo(@"D:\Test");
            FileInfo[] files = directory.GetFiles("*.txt");
            string testString = "THE CHARM OF OLD MONTEREY";
            foreach (FileInfo file in files)
            {
                values.File = file;
                values.SearchString = testString;
                Thread myThread = new Thread(new ParameterizedThreadStart(GetCountRepeatsInFile));
                myThread.Start(values);
                myThread.Join();
            }
            Console.WriteLine(Result.ToString());
            Console.ReadKey();
        }

        #endregion Methods

        #region Classes

        public class Values
        {
            #region Properties

            public FileInfo File { get; set; }
            public string SearchString { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }
}