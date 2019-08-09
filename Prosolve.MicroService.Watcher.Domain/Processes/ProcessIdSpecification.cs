using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Спецификация на соответствие идентификатору процесса.
    /// </summary>
    public class ProcessIdSpecification : SpecificationBase<IProcessEntity>
    {
        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="publicIdentifier">Публичный идентификатор.</param>
        public ProcessIdSpecification(Guid publicIdentifier)
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
        ///     Проверка наименования на длину.
        /// </summary>
        private static Expression<Func<IProcessEntity, bool>> Criteria(Guid publicIdentifier)
        {
            return x => x.Id.Public == publicIdentifier;
        }
    }
}
