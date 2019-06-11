﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Sharpdev.SDK.Layers.Domain.Events;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Сущность бизнес модели. Основная единица DDD.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        ///     Набор событий предметной области.
        /// </summary>
        private readonly ICollection<IDomainEvent> _domainEvents = new Collection<IDomainEvent>();

        /// <summary>
        ///     Набор условий ограничений.
        /// </summary>
        private readonly IReadOnlyCollection<IPolicy> _policies = new Collection<IPolicy>();

        /// <summary>
        ///     Конструктор для объекта <see cref="Entity" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        protected Entity(IIdentifier<IEntity> identifier, int currentVersion)
        {
            Id = identifier;
            CurrentVersion = currentVersion;
        }

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public IIdentifier<IEntity> Id { get; }

        /// <summary>
        ///     Версия объекта. Начальное значение 1. Шаг 1.
        /// </summary>
        public int CurrentVersion { get; }

        /// <summary>
        ///     Список всех событий предметной области.
        /// </summary>
        /// <returns>Список всех событий предметной области.</returns>
        public IReadOnlyCollection<IDomainEvent> DomainEvents()
        {
            return _domainEvents.ToArray();
        }

        /// <summary>
        ///     Добавление нового события предметной области.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        /// <summary>
        ///     Удаление события предметной области.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        /// <summary>
        ///     Удаление всех событий предметной области.
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        /// <summary>
        ///     Набор условий-ограничение.
        /// </summary>
        public IReadOnlyCollection<IPolicy> Policies()
        {
            return _policies;
        }
    }
}
