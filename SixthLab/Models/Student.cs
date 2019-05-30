using SixthLab.Attributes;

namespace SixthLab.Models
{
    [Couple(Pair = "Girl", Probability = 70, ChildType = "Girl")]
    [Couple(Pair = "PrettyGirl", Probability = 100, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 50, ChildType = "Girl")]
    public class Student : Human
    {
        #region Constructors

        public Student(string name) : base(name)
        {
        }

        public Student() : base("Student")
        {
        }

        #endregion Constructors
    }
}