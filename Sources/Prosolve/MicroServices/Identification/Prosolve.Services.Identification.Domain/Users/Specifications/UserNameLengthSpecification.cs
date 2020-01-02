using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Спецификация на ограничение длины наименования процесса.
    /// </summary>
    public sealed class UserNameLengthSpecification : SpecificationBase<IUserEntity>
    {
        /// <summary>
        ///     Максимальная длина наименования процесса.
        /// </summary>
        private const int MaxLength = 150;

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        /// todo Создать файл ресурсов для получения текстовых значений по пользователям.
        private static readonly string FailureMessage =
            $"Превышено максимальное значение длины ({MaxLength}) наименования процесса.";

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        public UserNameLengthSpecification()
            : base(Criteria, FailureMessage)
        {
        }

        /// <summary>
        ///     Проверка наименования на длину.
        /// </summary>
        private static Expression<Func<IUserEntity, bool>> Criteria => x =>
            x.FullName.GetFullName.Length <= MaxLength;
    }
}
