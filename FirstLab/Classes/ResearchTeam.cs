using FirstLab.Enums;
using System;
using System.Linq;

namespace FirstLab.Classes
{
    public class ResearchTeam
    {
        #region Fields

        private string _nameOfStudy;
        private string _nameOfOrganization;
        private int _registrationNumber;
        private TimeFrame _durationOfResearch;
        private Paper[] _listOfPublications;

        #endregion Fields

        #region Constructors

        public ResearchTeam()
        {
            _nameOfOrganization = default;
            _nameOfStudy = default;
            _registrationNumber = default;
            _durationOfResearch = default;
        }

        public ResearchTeam(string nameOfStudy, string nameOfOrganization, int registrationNumber, TimeFrame durationOfResearch, Paper[] listOfPublications)
        {
            _nameOfOrganization = nameOfOrganization;
            _nameOfStudy = nameOfStudy;
            _registrationNumber = registrationNumber;
            _durationOfResearch = durationOfResearch;
            _listOfPublications = listOfPublications;
        }

        #endregion Constructors

        #region Properties

        public string NameOfStudy
        {
            get => _nameOfStudy;
            set => _nameOfStudy = value;
        }

        public string NameOfOrganization { get => _nameOfOrganization; set => _nameOfOrganization = value; }

        public int RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }

        public TimeFrame DurationOfResearch { get => _durationOfResearch; set => _durationOfResearch = value; }

        public Paper[] ListOfPublication { get => _listOfPublications; set => _listOfPublications = value; }

        public Paper LastPublication
        {
            get
            {
                if (!(ListOfPublication == null || ListOfPublication.Length > 0))
                {
                    return ListOfPublication.Last();
                }
                return null;
            }
        }

        #endregion Properties

        #region Indexers

        public bool this[TimeFrame durationOfResearch] { get => DurationOfResearch == durationOfResearch; }

        #endregion Indexers

        #region Methods

        public void AddPapers(params Paper[] papers)
        {
            //TODO: use list or linq instead array for correct append
            int startCountOfPublication = _listOfPublications.Length;
            Array.Resize(ref _listOfPublications, _listOfPublications.Length + papers.Length);
            for (int i = startCountOfPublication, j = 0; i < _listOfPublications.Length; i++, j++)
            {
                _listOfPublications[i] = papers[j];
            }
        }

        public override string ToString()
        {
            return $"{_nameOfStudy} {_nameOfOrganization} {_registrationNumber} {_durationOfResearch}\n\t{string.Join("\n\t", _listOfPublications.Select(x => x.ToString()).ToArray())}";
        }

        public virtual string ToShortString()
        {
            return $"{_nameOfStudy} {_nameOfOrganization} {_registrationNumber} {_durationOfResearch}";
        }

        #endregion Methods
    }
}