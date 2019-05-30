using FourthLab.Enums;
using FourthLab.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FourthLab.Classes
{
    public class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        #region Fields

        private string _name;
        private TimeFrame _durationOfResearch;
        private List<Paper> _publications;
        private List<Person> _members;

        #endregion Fields

        #region Constructors

        public ResearchTeam() : base()
        {
            _name = default;
            _durationOfResearch = default;
        }

        public ResearchTeam(string name, string nameOfStudy, int registrationNumber, TimeFrame durationOfResearch, List<Paper> publications) : base(name, registrationNumber)
        {
            _name = nameOfStudy;
            _durationOfResearch = durationOfResearch;
            _publications = publications;
        }

        #endregion Constructors

        #region Properties

        public new string Name
        {
            get => _name;
            set => _name = value;
        }

        public TimeFrame DurationOfResearch { get => _durationOfResearch; set => _durationOfResearch = value; }

        public List<Paper> Publication { get => _publications; set => _publications = value; }

        public List<Person> Members { get => _members; set => _members = value; }

        public Team Team { get => new Team(name, registryNumber); set { name = value.Name; registryNumber = value.RegistryNumber; } }

        public Paper LastPublication
        {
            get
            {
                if (!(Publication == null || Publication.Count > 0))
                {
                    return Publication.Last();
                }
                return null;
            }
        }

        #endregion Properties

        #region Indexers

        public bool this[TimeFrame durationOfResearch] => DurationOfResearch == durationOfResearch;

        #endregion Indexers

        #region Methods

        public static bool operator ==(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return researchTeam1.Equals(researchTeam2);
        }

        public static bool operator !=(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return !researchTeam1.Equals(researchTeam2);
        }

        public ResearchTeam ShallowCopy()
        {
            return (ResearchTeam)MemberwiseClone();
        }

        public IEnumerable<Paper> GetPublishingInRecentYear(int year)
        {
            var publications = _publications.Where(x => (DateTime.Now.Year - x.DateOfPublish.Year) < year);
            if (publications.Count() < 0)
            {
                yield break;
            }

            foreach (Paper paper in publications)
            {
                yield return paper;
            }
        }

        public void AddPersons(params Person[] personsList)
        {
            Members.AddRange(personsList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetMembersWithoutAnyPublish();
        }

        public IEnumerable<Person> GetMembersWithoutAnyPublish()
        {
            var members = _members.Where(x => !_publications.Any(p => p.Author.Equals(x)));
            if (members.Count() < 0)
            {
                yield break;
            }

            foreach (Person person in members)
            {
                yield return person;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            foreach (var paper in papers)
            {
                _publications.Append(paper);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{_name} {_durationOfResearch}\n\t{string.Join("\n\t", _publications.Select(x => x.ToString()).ToArray())}";
        }

        public virtual string ToShortString()
        {
            return base.ToString() + $"{_name} {_durationOfResearch}";
        }

        public override object DeepCopy()
        {
            ResearchTeam research = new ResearchTeam(name, _name, registryNumber, _durationOfResearch, _publications);
            research._members = _members;
            return research;
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Name.CompareTo(y.Name);
        }

        #endregion Methods
    }
}