﻿using System.Collections.Generic;

using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Набор параметров для поиска пользователей <see cref="IUser" />.
    /// </summary>
    public interface IUserSearchParameters : ISearchParameters<IUser>
    {
        /// <summary>
        ///     Часть электронного адреса для поиска пользователей.
        /// </summary>
        ISearchParameter<IEnumerable<EmailAddress>> EmailAddresses { get; set; }

        /// <summary>
        ///     Часть фамилии для поиска пользователей.
        /// </summary>
        ISearchParameter<string> FirstNamePart { get; set; }

        /// <summary>
        ///     Часть имени для поиска пользователей.
        /// </summary>
        ISearchParameter<string> SurnamePart { get; set; }

        /// <summary>
        ///     Часть отчества для поиска пользователей.
        /// </summary>
        ISearchParameter<string> PatronymicPart { get; set; }
    }
}
