using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Infrastructure.Statuses;

namespace Sharpdev.SDK.Presentation
{
    /// <summary>
    ///     Базовый класс для сервиса предоставляемого для бизнеса.
    /// </summary>
    public abstract class ServiceBase : HasStatusBase<ServiceStatus>, IService
    {
        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Инициализация объекта <see cref="ServiceBase"/>.
        /// </summary>
        /// <param name="unitOfWork">Механизм для управления транзакциями.</param>
        protected ServiceBase(IUnitOfWork unitOfWork): base(ServiceStatus.Up)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
