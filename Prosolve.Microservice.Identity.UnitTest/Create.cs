using Moq;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

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
        public static UserBuilder User()
        {
            return new UserBuilder();
        }

        /// <summary>
        ///     Создание электронного адреса.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>Готовый для тестов адрес электронной почты.</returns>
        public static EmailAddressBuilder EmailAddress(string emailAddress)
        {
            return new EmailAddressBuilder(emailAddress);
        }

        /// <summary>
        ///     Создание сервиса для работы с пользователем.
        /// </summary>
        /// <returns>Готовый для тестов сервис для работы с пользователем.</returns>
        public static IdentityServiceBuilder IdentityService()
        {
            return new IdentityServiceBuilder();
        }

        /// <summary>
        ///     Создание набор для поиска пользователя.
        /// </summary>
        /// <returns>Готовый для тестов набор параметров для поиска.</returns>
        public static UserSearchParametersBuilder UserSearchParameters()
        {
            return new UserSearchParametersBuilder();
        }

        public static IdentifierBuilder<TEntity> Identifier<TEntity>()
            where TEntity : IEntity<TEntity>
        {
            return new IdentifierBuilder<TEntity>();
        }
    }
}
