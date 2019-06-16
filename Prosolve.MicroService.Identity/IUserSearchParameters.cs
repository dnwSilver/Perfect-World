using Sharpdev.SDK.Layers.Domain.Factories;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Набор параметров для поиска пользователей <see cref="IUser" />.
    /// </summary>
    public interface IUserSearchParameters : ISearchParameters<IUser>
    {
        /// <summary>
        ///     Часть электронного адреса для поиска пользователей.
        /// </summary>
        /// <param name="emailAddressPart">Искомая часть.</param>
        /// <returns>Набор параметров <see cref="IUserSearchParameters" />.</returns>
        IUserSearchParameters EmailAddressPart(string emailAddressPart);

        /// <summary>
        ///     Часть фамилии для поиска пользователей.
        /// </summary>
        /// <param name="firstNamePart">Искомая часть.</param>
        /// <returns>Набор параметров <see cref="IUserSearchParameters" />.</returns>
        IUserSearchParameters FirstNamePart(string firstNamePart);

        /// <summary>
        ///     Часть имени для поиска пользователей.
        /// </summary>
        /// <param name="surnamePart">Искомая часть.</param>
        /// <returns>Набор параметров <see cref="IUserSearchParameters" />.</returns>
        IUserSearchParameters SurnamePart(string surnamePart);

        /// <summary>
        ///     Часть отчества для поиска пользователей.
        /// </summary>
        /// <param name="patronymicPart">Искомая часть.</param>
        /// <returns>Набор параметров <see cref="IUserSearchParameters" />.</returns>
        IUserSearchParameters PatronymicPart(string patronymicPart);
    }
}
