using SixthLab.Interfaces;

namespace SixthLab.Models
{
    public class Book : IHasName
    {
        #region Constructors

        public Book()
        {
            Name = "Book";
        }

        public Book(string name)
        {
            Name = name;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; }

        #endregion Properties
    }
}