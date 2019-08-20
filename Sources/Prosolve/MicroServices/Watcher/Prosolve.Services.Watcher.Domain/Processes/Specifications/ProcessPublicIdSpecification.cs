using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Watcher.Domain.Processes.Specifications
{
    /// <summary>
    ///     Спецификация на соответствие идентификатору процесса.
    /// </summary>
    public class ProcessPublicIdSpecification : SpecificationBase<IProcessEntity>
    {
        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="publicIdentifier">Публичный идентификатор.</param>
        public ProcessPublicIdSpecification(Guid publicIdentifier)
            : base(Criteria(publicIdentifier), FailureMessage(publicIdentifier))
        {
        }

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private static string FailureMessage(Guid publicIdentifier)
        {
            return string.Format(ProcessResources.IdSpecification,
                                 nameof(IProcessEntity),
                                 publicIdentifier);
        }

        /// <summary>
        ///     Проверка соответствия идентификатору.
        /// </summary>
        private static Expression<Func<IProcessEntity, bool>> Criteria(Guid publicIdentifier)
        {
            return x => x.Id.Public == publicIdentifier;
        }
    }
}
