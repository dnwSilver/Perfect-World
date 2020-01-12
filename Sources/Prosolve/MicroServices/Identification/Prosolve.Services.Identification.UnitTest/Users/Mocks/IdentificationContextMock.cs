using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Users.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Mocks
{
    /// <summary>
    ///     Виртуальный контекст для базы данных. Данные будем хранить в памяти.
    /// </summary>
    internal class IdentificationContextMock : TestObjectGeneratorBase<IdentificationContext>
    {
        private readonly IdentificationContext _identificationContext;

        /// <summary>
        ///     Инициализация контекста данных хранимого в памяти.
        /// </summary>
        public IdentificationContextMock()
        {
            var services = new ServiceCollection();
            services.AddDbContext<IdentificationContext>(options => options.UseSqlite($"DataSource=:memory{Guid.NewGuid()}:"), ServiceLifetime.Transient);

            var serviceProvider = services.BuildServiceProvider();
            _identificationContext = serviceProvider.GetService<IdentificationContext>();
            _identificationContext.Database.OpenConnection();
            _identificationContext.Database.EnsureCreated();
        }

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IdentificationContext Allocate(int testObjectNumber)
        {
            return _identificationContext;
        }

        /// <summary>
        ///     Добавление нового пользователя в контекст источника данных.
        /// </summary>
        /// <param name="userDataModel">Новый пользователь.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public void With(UserDataModel userDataModel)
        {
            _identificationContext.Users.Add(userDataModel);
            _identificationContext.SaveChanges();
        }

        /// <summary>
        ///     Добавление новых пользователей в контекст источника данных.
        /// </summary>
        /// <param name="userDataModels">Список новых пользователей.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public IdentificationContextMock With(IEnumerable<UserDataModel> userDataModels)
        {
            foreach(var userDataModel in userDataModels)
                With(userDataModel);

            return this;
        }
    }
}
