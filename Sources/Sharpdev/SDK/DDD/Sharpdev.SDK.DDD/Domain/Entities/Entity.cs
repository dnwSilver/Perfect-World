﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Sharpdev.SDK.Domain.Events;
using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Domain.Entities
{
    /// <summary>
    ///     Сущность бизнес модели. Основная единица DDD.
    /// </summary>
    public abstract class Entity<TEntity> : IEntity<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Набор событий предметной области.
        /// </summary>
        private readonly ICollection<IDomainEvent> _domainEvents = new Collection<IDomainEvent>();

        /// <summary>
        ///     Набор условий ограничений.
        /// </summary>
        private readonly IEnumerable _policies = new Collection<IPolicy>();

        /// <summary>
        ///     Конструктор для объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        protected Entity(IIdentifier<TEntity>? identifier, int currentVersion)
        {
            if (identifier!.ReturnFailure())
                throw new ArgumentNullException(nameof(identifier));
            
            this.Id = identifier!;
            this.CurrentVersion = currentVersion;
            this.IsSoftDelete = true;
        }

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public IIdentifier<TEntity> Id { get; }

        /// <summary>
        ///     Версия объекта. Начальное значение 1. Шаг 1.
        /// </summary>
        public int CurrentVersion { get; }

        /// <summary>
        ///     Признак  безопасного  удаления  объекта.  Информация по объекту не будет стираться,
        ///     у объекта  будет выставлен  признак его  блокировки и он перестанет  участвовать во
        ///     всех  операциях в системе.  Разблокировать  можно  будет  только  ручным  образом в
        ///     источнике данных.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - используется безопасное удаление.
        ///     <see langword="false" /> - используется не безопасное удаление.
        /// </returns>
        public bool IsSoftDelete { get; }

        /// <summary>
        ///     Список всех событий предметной области.
        /// </summary>
        /// <returns>Список всех событий предметной области.</returns>
        public IEnumerable DomainEvents()
        {
            return this._domainEvents.ToArray();
        }

        /// <summary>
        ///     Добавление нового события предметной области.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            this._domainEvents.Add(domainEvent);
        }

        /// <summary>
        ///     Удаление события предметной области.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            this._domainEvents.Remove(domainEvent);
        }

        /// <summary>
        ///     Удаление всех событий предметной области.
        /// </summary>
        public void ClearDomainEvents()
        {
            this._domainEvents.Clear();
        }

        /// <summary>
        ///     Набор условий-ограничение.
        /// </summary>
        public IEnumerable Policies()
        {
            return this._policies;
        }
    }
}
