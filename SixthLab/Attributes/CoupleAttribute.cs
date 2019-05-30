using System;

namespace SixthLab.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class Couple : Attribute
    {
        #region Properties

        public string Pair { get; set; }
        public int Probability { get; set; }
        public string ChildType { get; set; }

        #endregion Properties
    }
}