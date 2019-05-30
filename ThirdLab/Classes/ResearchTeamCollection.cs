using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdLab.Classes
{
    internal class ResearchTeamCollection
    {
        #region Fields

        private List<ResearchTeam> _researchTeams;

        #endregion Fields

        #region Constructors

        public ResearchTeamCollection()
        {
            _researchTeams = new List<ResearchTeam>();
        }

        #endregion Constructors

        #region Properties

        public int MinRegistryNumber
        {
            get
            {
                if (_researchTeams.Count < 1)
                {
                    return default;
                }
                return _researchTeams.Select(t => t.RegistryNumber).Min();
            }
        }

        public List<ResearchTeam> GetTwoYearsLongResearchTeams
        {
            get
            {
                return _researchTeams.Where(x => x.DurationOfResearch == Enums.TimeFrame.TwoYears).ToList();
            }
        }

        #endregion Properties

        #region Methods

        public List<ResearchTeam> NGroup(int value)
        {
            List<IGrouping<int, ResearchTeam>> group = _researchTeams.GroupBy(x => x.Members?.Count ?? 0).ToList();
            return group[value].ToList();
        }

        public void AddDefaults(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _researchTeams.Add(new ResearchTeam());
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            foreach (var researchTeam in researchTeams)
            {
                this._researchTeams.Add(researchTeam);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _researchTeams.Select(x => x.ToString()));
        }

        public virtual string ToShortString()
        {
            return string.Join(Environment.NewLine, _researchTeams.Select(x => x.ToShortString()));
        }

        public void SortByRegistrationNumber()
        {
            _researchTeams.Sort();
        }

        public void SortByExploreTheme()
        {
            _researchTeams.Sort(new ResearchTeam());
        }

        public void SortByCountOfPublishing()
        {
            _researchTeams.Sort(new ResearchTeamComparer());
        }

        #endregion Methods
    }
}