using System;

namespace FirstLab.Classes
{
    public class Person
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private DateTime _birthday;

        #endregion Fields

        #region Constructors

        public Person(string firstName, string lastName, DateTime birthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthday = birthday;
        }

        public Person()
        {
            _firstName = default;
            _lastName = default;
            _birthday = default;
        }

        #endregion Constructors

        #region Properties

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }

        public int YearOfBirthday
        {
            get => _birthday.Year;
            set => _birthday.AddYears(value - _birthday.Year);
        }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Birthday}";
        }

        public virtual string ToShortString()
        {
            return $"{FirstName} {LastName}";
        }

        #endregion Methods
    }
}