using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identity.UnitTest.Users.Mocks;
using Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest
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
    internal static class Create
    {
        /// <summary>
        ///     Создание пользователя.
        /// </summary>
        /// <returns>Готовый для тестов пользователь.</returns>
        internal static UserObjectGenerator User => new UserObjectGenerator();

        /// <summary>
        ///     Создание модели для пользователя.
        /// </summary>
        /// <returns>Готовый для тестов пользователь.</returns>
        internal static UserDataModelObjectGenerator UserDataModel =>
            new UserDataModelObjectGenerator();

        /// <summary>
        ///     Создание контекста для сервиса идентификации.
        /// </summary>
        internal static VirtualIdentificationContextMock IdentificationContext =>
            new VirtualIdentificationContextMock();

        /// <summary>
        ///     Создание эмуляции интеграционной шины.
        /// </summary>
        internal static VirtualIntegrateBusMock IntegrationBus => new VirtualIntegrateBusMock();

        /// <summary>
        ///     Создание электронного адреса.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>Готовый для тестов адрес электронной почты.</returns>
        internal static EmailAddressGenerator EmailAddress(string emailAddress)
            =>new EmailAddressGenerator(emailAddress);

        /// <summary>
        ///     Создание строителя для <see cref="IUserEntity" />.
        /// </summary>
        internal static UserBuilderGenerator UserBuilder => new UserBuilderGenerator();

        /// <summary>
        ///     Создание идентификатора <see cref="IIdentifier{TOwner}" />.
        /// </summary>
        /// <typeparam name="TEntity"> Доменная сущность. </typeparam>
        /// <returns>Уникальный идентификатор.</returns>
        internal static IdentifierGenerator<TEntity> Identifier<TEntity>()
            where TEntity : IEntity<TEntity>
            =>new IdentifierGenerator<TEntity>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static PhoneNumberGenerator PhoneNumber
            =>new PhoneNumberGenerator();
    }
}
