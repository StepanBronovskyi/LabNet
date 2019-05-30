using FifthLab.Interfaces;
using System;
using System.Runtime.Serialization;

namespace FifthLab.Classes
{
    [DataContract]
    public class Team : INameAndCopy, IComparable
    {
        #region Fields

        protected string name;
        protected int registryNumber;

        #endregion Fields

        #region Constructors

        public Team()
        {
            name = default;
            registryNumber = default;
        }

        public Team(string name, int registryNumber)
        {
            Name = name;
            RegistryNumber = registryNumber;
        }

        #endregion Constructors

        #region Properties

        [DataMember]
        public int RegistryNumber
        {
            get => registryNumber;
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{nameof(RegistryNumber)} must be grater than 0");
                }
                registryNumber = value;
            }
        }

        [DataMember]
        public string Name { get => name; set => name = value; }

        #endregion Properties

        #region Methods

        public int CompareTo(object obj)
        {
            return RegistryNumber.CompareTo((obj as Team).RegistryNumber);
        }

        public virtual object DeepCopy()
        {
            return new Team(name, registryNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is Team team)
            {
                return Equals(team);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = (hash * 29) + name.GetHashCode();
            return (hash * 29) + registryNumber;
        }

        public override string ToString()
        {
            return $"{Name} has registry number {registryNumber}";
        }

        private bool Equals(Team team)
        {
            return (team != null)
                && string.Equals(name, team.Name, StringComparison.InvariantCultureIgnoreCase)
                && registryNumber == team.RegistryNumber;
        }

        #endregion Methods
    }
}