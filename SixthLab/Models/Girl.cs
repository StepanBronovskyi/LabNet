using SixthLab.Attributes;

namespace SixthLab.Models
{
    [Couple(Pair = "Student", Probability = 70, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 30, ChildType = "SmartGirl")]
    public class Girl : Human
    {
        #region Constructors

        public Girl() : base("Girl")
        {
        }

        public Girl(string name) : base(name)
        {
        }

        #endregion Constructors
    }
}