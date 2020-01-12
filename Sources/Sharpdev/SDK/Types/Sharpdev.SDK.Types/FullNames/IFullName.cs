namespace Sharpdev.SDK.Types.FullNames
{
    /// <summary>
    ///     Фамилия имя и отчество человека.
    /// </summary>
    public interface IFullName
    {
        /// <summary>
        ///     Фамилия.
        /// </summary>
        string Surname { get; }

        /// <summary>
        ///     Имя.
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///     Отчество.
        /// </summary>
        string Patronymic { get; }
    }
}
