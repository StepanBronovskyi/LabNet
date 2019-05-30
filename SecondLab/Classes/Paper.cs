using System;

namespace SecondLab.Classes
{
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

        public string NameOfPublish { get; set; }
        public Person Author { get; set; }
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