using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Набор параметров для пользователей.
    /// </summary>
    public class UserSearchParameters : SearchParametersBase<IUser>, IUserSearchParameters
    {
        /// <summary>
        ///     Часть электронного адреса для поиска пользователей.
        /// </summary>
        public ISearchParameter<IEnumerable<EmailAddress>> EmailAddresses { get; set; } =
            new SearchParameter<IEnumerable<EmailAddress>>(Enumerable.Empty<EmailAddress>());

        /// <summary>
        ///     Часть фамилии для поиска пользователей.
        /// </summary>
        public ISearchParameter<string> FirstNamePart { get; set; } = new SearchParameter<string>(string.Empty);

        /// <summary>
        ///     Часть имени для поиска пользователей.
        /// </summary>
        public ISearchParameter<string> SurnamePart { get; set; } = new SearchParameter<string>(string.Empty);

        /// <summary>
        ///     Часть отчества для поиска пользователей.
        /// </summary>
        public ISearchParameter<string> PatronymicPart { get; set; } = new SearchParameter<string>(string.Empty);
    }
}
