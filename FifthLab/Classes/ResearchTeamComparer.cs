using System.Collections.Generic;

namespace FifthLab.Classes
{
    public class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        #region Methods

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Publication.Count.CompareTo(y.Publication.Count);
        }

        #endregion Methods
    }
}