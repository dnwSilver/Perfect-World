﻿using System;
using System.Collections;
using System.Collections.ObjectModel;

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
        ///     Набор условий-ограничение.
        /// </summary>
        public IEnumerable Policies()
        {
            return this._policies;
        }
    }
}
