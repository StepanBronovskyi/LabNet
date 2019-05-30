using System;

namespace SixthLab
{
    internal class InvalidCoupleArguments : Exception
    {
        #region Constructors

        public InvalidCoupleArguments(string message) : base(message)
        {
        }

        #endregion Constructors
    }
}