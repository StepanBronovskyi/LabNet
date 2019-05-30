using SecondLab.Enums;
using SecondLab.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SecondLab.Classes
{
    public class ResearchTeam : Team, INameAndCopy, IEnumerable
    {
        #region Fields

        private string _name;
        private TimeFrame _durationOfResearch;
        private Paper[] _publications;
        private Person[] _members;

        #endregion Fields

        #region Constructors

        public ResearchTeam() : base()
        {
            _name = default;
            _durationOfResearch = default;
        }

        public ResearchTeam(string name, string nameOfStudy, int registrationNumber, TimeFrame durationOfResearch, Paper[] publications) : base(name, registrationNumber)
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

        public Paper[] Publication { get => _publications; set => _publications = value; }

        public Person[] Members { get => _members; set => _members = value; }

        public Team Team { get => new Team(name, registryNumber); set { name = value.Name; registryNumber = value.RegistryNumber; } }

        public Paper LastPublication
        {
            get
            {
                if (!(Publication == null || Publication.Length > 0))
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

        public void AddMembers(params Person[] members)
        {
            //TODO: use list or linq instead array for correct append
            int startCountOfMember = _members.Length;
            Array.Resize(ref _members, _members.Length + members.Length);
            for (int i = startCountOfMember, j = 0; i < _members.Length; i++, j++)
            {
                _members[i] = members[j];
            }
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
            //TODO: use list or linq instead array for correct append
            int startCountOfPublication = _publications.Length;
            Array.Resize(ref _publications, _publications.Length + papers.Length);
            for (int i = startCountOfPublication, j = 0; i < _publications.Length; i++, j++)
            {
                _publications[i] = papers[j];
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

        #endregion Methods
    }
}