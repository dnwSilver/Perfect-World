﻿using System;
using System.Threading.Tasks;

using Microsoft.VisualBasic;

using Sharpdev.SDK.Infrastructure.Integrations;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Виртуальная шина для тестов.
    /// </summary>
    internal class IntegrateBusMock : IIntegrateBus
    {
        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public IntegrationBusStatus Status { get; private set; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(IntegrationBusStatus newStatus)
        {
            this.Status = newStatus;
        }

        /// <summary>
        ///     Публикация нового события.
        /// </summary>
        /// <param name="event">Событие миграции данных.</param>
        /// <remarks>
        ///     Шина событий передает  полученное  событие  интеграции  всем  микрослужбам  и  даже
        ///     внешним приложениям, которые подписаны на  это  событие.  Этот  метод  используется
        ///     микрослужбой, которая публикует событие.
        /// </remarks>
        public Task PublishAsync(IIntegrationEvent @event)
        {
            // Список события для отправки в шину данных.
            var events = new Collection();
            events.Add(@event);
            events.Clear();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Подписка на событие.
        /// </summary>
        /// <typeparam name="TIntegrationEvent">Событие миграции данных.</typeparam>
        /// <typeparam name="TIntegrationEventHandler">Обработчик события.</typeparam>
        public Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEvent : IIntegrationEvent
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Отписка от получения событий.
        /// </summary>
        /// <typeparam name="TIntegrationEvent">Событие миграции данных.</typeparam>
        /// <typeparam name="TIntegrationEventHandler">Обработчик события.</typeparam>
        public Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEvent : IIntegrationEvent
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
        {
            throw new NotImplementedException();
        }
    }
}
