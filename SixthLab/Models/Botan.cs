using SixthLab.Attributes;

namespace SixthLab.Models
{
    [Couple(Pair = "Girl", Probability = 70, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 100, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 80, ChildType = "Book")]
    public class Botan : Human
    {
        #region Constructors

        public Botan() : base("Botan")
        {
        }

        public Botan(string name) : base(name)
        {
        }

        #endregion Constructors
    }
}