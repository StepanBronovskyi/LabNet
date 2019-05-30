using System;

namespace FourthLab
{
    public class TeamsJournalEntry
    {
        #region Constructors

        public TeamsJournalEntry(string name, string change, int index)
        {
            Name = name;
            TypeOfChange = change;
            IndexOfElement = index;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; set; }
        public string TypeOfChange { get; set; }
        public int IndexOfElement { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return Environment.NewLine +
                   $"Collection : {Name}" +
                   Environment.NewLine +
                   $"Type of change : {TypeOfChange}" +
                   Environment.NewLine +
                   $"Index of element : {IndexOfElement}";
        }

        #endregion Methods
    }
}