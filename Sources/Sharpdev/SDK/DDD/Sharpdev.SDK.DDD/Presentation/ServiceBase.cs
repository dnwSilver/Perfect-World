using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Infrastructure.Statuses;

namespace Sharpdev.SDK.Presentation
{
    /// <summary>
    ///     Базовый класс для сервиса предоставляемого для бизнеса.
    /// </summary>
    public abstract class ServiceBase<TBoundedContext> : HasStatusBase<ServiceStatus>, IService
        where TBoundedContext: IBoundedContext
    {
        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        protected readonly IUnitOfWork<TBoundedContext> UnitOfWork;

        /// <summary>
        /// Инициализация объекта <see cref="ServiceBase{TBoundedContext}"/>.
        /// </summary>
        /// <param name="unitOfWork">Механизм для управления транзакциями.</param>
        protected ServiceBase(IUnitOfWork<TBoundedContext> unitOfWork): base(ServiceStatus.Up)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
