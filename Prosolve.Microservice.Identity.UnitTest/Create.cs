using Prosolve.MicroService.Identity.UnitTest.Users.Stubs;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest
{
    /// <summary>
    ///     Шаблон простой: создаём статический класс и собираем в него всех строителей.
    /// </summary>
    /// <remarks>
    ///     ObjectMother  начинается  с  шаблона factory путем доставки готовых объектов, готовых к
    ///     тестированию, с помощью  простого вызова метода. Он  выходит за пределы области factory
    ///     на  облегчая  настройку  созданных  объектов,  предоставление  методов  для  обновления
    ///     объектов  во  время  испытаний и если  необходимо, удаление объекта  из  базы данных по
    ///     завершении теста.
    ///     Некоторые причины использования ObjectMother:
    ///     - Уменьшите дублирование кода в тестах, повысив надежность обслуживания
    ///     - Сделать тестовые объекты супер-легкодоступными, побуждая разработчиков писать тесты.
    ///     - Каждый тест работает со свежими данными.
    ///     - Тесты всегда очищаются после себя.
    /// </remarks>
    public static class Create
    {
        /// <summary>
        ///     Создание пользователя.
        /// </summary>
        /// <returns>Готовый для тестов пользователь.</returns>
        public static UserStub User()
        {
            return new UserStub();
        }

        /// <summary>
        ///     Создание сервиса для работы с пользователем.
        /// </summary>
        /// <returns>Готовый для тестов сервис для работы с пользователем.</returns>
        public static IdentityServiceStub IdentityService()
        {
            return new IdentityServiceStub();
        }

        /// <summary>
        ///     Создание набор для поиска пользователя.
        /// </summary>
        /// <returns>Готовый для тестов набор параметров для поиска.</returns>
        public static UserSearchParametersStub UserSearchParameters()
        {
            return new UserSearchParametersStub();
        }

        /// <summary>
        ///     Создание электронного адреса.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>Готовый для тестов адрес электронной почты.</returns>
        public static EmailAddressStub EmailAddress(string emailAddress)
        {
            return new EmailAddressStub(emailAddress);
        }

        public static IdentifierStub<TEntity> Identifier<TEntity>()
            where TEntity : IEntity<TEntity>
        {
            return new IdentifierStub<TEntity>();
        }
    }
}
