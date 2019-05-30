namespace FifthLab.Interfaces
{
    internal interface INameAndCopy
    {
        #region Properties

        string Name { get; set; }

        #endregion Properties

        #region Methods

        object DeepCopy();

        #endregion Methods
    }
}