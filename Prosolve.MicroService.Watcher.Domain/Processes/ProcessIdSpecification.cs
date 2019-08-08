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
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private static readonly string FailureMessage =
            string.Format(ProcessResources.IdSpecification, _publicIdentifier);

        /// <summary>
        ///     Публичный идентификатор.
        /// </summary>
        private readonly Guid _publicIdentifier;

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="publicIdentifier">Публичный идентификатор.</param>
        public ProcessIdSpecification(Guid publicIdentifier)
            : base(Criteria(publicIdentifier), FailureMessage)
        {
            this._publicIdentifier = publicIdentifier;
        }

        /// <summary>
        ///     Проверка наименования на длину.
        /// </summary>
        private static Expression<Func<IProcessEntity, bool>> Criteria(Guid publicIdentifier) => x =>
            x.Id.Public == publicIdentifier;
    }
}
