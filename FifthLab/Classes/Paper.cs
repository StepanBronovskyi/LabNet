using System;
using System.Runtime.Serialization;

namespace FifthLab.Classes
{
    [DataContract]
    public class Paper
    {
        #region Constructors

        public Paper()
        {
            NameOfPublish = default;
            Author = new Person();
            DateOfPublish = default;
        }

        public Paper(string nameOfPublish, Person author, DateTime dateOfPublish)
        {
            NameOfPublish = nameOfPublish;
            Author = author;
            DateOfPublish = dateOfPublish;
        }

        #endregion Constructors

        #region Properties

        [DataMember]
        public string NameOfPublish { get; set; }

        [DataMember]
        public Person Author { get; set; }

        [DataMember]
        public DateTime DateOfPublish { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"{NameOfPublish} {Author.ToString()} {DateOfPublish}";
        }

        #endregion Methods
    }
}