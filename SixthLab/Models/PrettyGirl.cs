using SixthLab.Attributes;

namespace SixthLab.Models
{
    [Couple(Pair = "Student", Probability = 40, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 10, ChildType = "PrettyGirl")]
    public class PrettyGirl : Human
    {
        #region Constructors

        public PrettyGirl() : base("PrettyGirl")
        {
        }

        public PrettyGirl(string name) : base(name)
        {
        }

        #endregion Constructors
    }
}