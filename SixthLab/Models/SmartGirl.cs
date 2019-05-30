using SixthLab.Attributes;

namespace SixthLab.Models
{
    [Couple(Pair = "Student", Probability = 20, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 50, ChildType = "Book")]
    public class SmartGirl : Human
    {
        #region Constructors

        public SmartGirl() : base("SmartGirl")
        {
        }

        public SmartGirl(string name) : base(name)
        {
        }

        #endregion Constructors
    }
}