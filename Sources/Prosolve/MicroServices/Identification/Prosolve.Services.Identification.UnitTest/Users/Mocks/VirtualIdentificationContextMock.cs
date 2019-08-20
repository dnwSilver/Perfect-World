using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Entities.Users.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Mocks
{
    /// <summary>
    ///     Виртуальный контекст для базы данных. Данные будем хранить в памяти.
    /// </summary>
    internal class VirtualIdentificationContextMock : TestStubBase<IdentificationContext>
    {
        /// <summary>
        ///     Настройки для виртуального источника данных.
        /// </summary>
        private readonly DbContextOptions<IdentificationContext> _options;

        /// <summary>
        ///     Инициализация контекста данных хранимого в памяти.
        /// </summary>
        public VirtualIdentificationContextMock()
        {
            this._options = new DbContextOptionsBuilder<IdentificationContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
        }

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IdentificationContext AllocateStub(int stubNumber)
        {
            return new IdentificationContext(this._options);
        }

        /// <summary>
        ///     Добавление нового пользователя в контекст источника данных.
        /// </summary>
        /// <param name="userDataModel">Новый пользователь.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public VirtualIdentificationContextMock With(UserDataModel userDataModel)
        {
            using var identificationContext = new IdentificationContext(this._options);
            identificationContext.Users.Add(userDataModel);
            identificationContext.SaveChanges();

            return this;
        }

        /// <summary>
        ///     Добавление новых пользователей в контекст источника данных.
        /// </summary>
        /// <param name="userDataModels">Список новых пользователей.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public VirtualIdentificationContextMock With(IEnumerable<UserDataModel> userDataModels)
        {
            foreach(var userDataModel in userDataModels)
                this.With(userDataModel);

            return this;
        }
    }
}
