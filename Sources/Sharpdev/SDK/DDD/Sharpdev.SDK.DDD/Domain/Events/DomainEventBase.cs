using System;

using Sharpdev.SDK.Domain.Entities;

namespace Sharpdev.SDK.Domain.Events
{
    /// <summary>
    /// Базовый класс для доменного события.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности с которой связанно событие.</typeparam>
    public abstract class DomainEventBase<TEntity> : IDomainEvent<TEntity>
        where TEntity: IEntity<TEntity>
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор события. </param>
        /// <param name="creationDate"> Дата события (UTC+0). </param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        protected DomainEventBase(Guid id, DateTime creationDate, string data)
        {
            Id = id;
            CreationDate = creationDate;
            Data = data;
        }

        /// <summary>
        ///     Уникальный идентификатор события.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     Дата события (UTC+0).
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        ///     Информация о событии. Желательно хранить её в JSON.
        /// </summary>
        public string Data { get; }
    }
}
