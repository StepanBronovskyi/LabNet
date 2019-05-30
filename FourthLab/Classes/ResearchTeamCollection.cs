using System;
using System.Collections.Generic;
using System.Linq;

namespace FourthLab.Classes
{
    public class ResearchTeamCollection
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

        #region Delegates

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        #endregion Delegates

        #region Events

        public event TeamListHandler ResearchTeamAdded;

        public event TeamListHandler ResearchTeamInserted;

        #endregion Events

        #region Properties

        public string Name { get; set; }

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
                ResearchTeamAdded?.Invoke(_researchTeams, new TeamListHandlerEventArgs(Name, "Added", _researchTeams.Count - 1));
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            foreach (var researchTeam in researchTeams)
            {
                this._researchTeams.Add(researchTeam);
                ResearchTeamAdded?.Invoke(_researchTeams, new TeamListHandlerEventArgs(Name, "Added", _researchTeams.Count - 1));
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

        public void InsertAt(int index, ResearchTeam researchTeam)
        {
            if (researchTeam == null)
                return;

            if (index >= _researchTeams.Count)
            {
                _researchTeams.Add(researchTeam);
                ResearchTeamAdded?.Invoke(researchTeam, new TeamListHandlerEventArgs(Name, "Added", _researchTeams.Count - 1));
                return;
            }

            _researchTeams.Insert(index, researchTeam);
            ResearchTeamInserted?.Invoke(researchTeam, new TeamListHandlerEventArgs(Name, "Inserted", _researchTeams.IndexOf(researchTeam, index)));
        }

        #endregion Methods
    }
}