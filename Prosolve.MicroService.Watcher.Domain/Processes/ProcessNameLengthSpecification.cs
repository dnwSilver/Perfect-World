using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Спецификация на ограничение длины наименования процесса.
    /// </summary>
    public sealed class ProcessNameLengthSpecification : SpecificationBase<IProcessEntity>
    {
        /// <summary>
        ///     Максимальная длина наименования процесса.
        /// </summary>
        private const int MaxLength = 50;

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private static readonly string FailureMessage =
            string.Format(ProcessResources.NameLengthSpecification, MaxLength);

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        public ProcessNameLengthSpecification()
            : base(Criteria, FailureMessage)
        {
        }

        /// <summary>
        ///     Проверка наименования на длину.
        /// </summary>
        private static Expression<Func<IProcessEntity, bool>> Criteria => x => x.Name.Length < MaxLength;
    }
}
