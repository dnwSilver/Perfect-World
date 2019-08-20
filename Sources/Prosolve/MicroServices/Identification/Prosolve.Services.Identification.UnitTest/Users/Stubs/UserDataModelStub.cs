using System;

using Prosolve.Services.Identification.Entities.Users.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="UserDataModel" />.
    /// </summary>
    internal class UserDataModelStub : TestStubBase<UserDataModel>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override UserDataModel AllocateStub(int stubNumber)
        {
            var userDataModel = new UserDataModel();
            userDataModel.PrivateId = stubNumber;
            userDataModel.PublicId = Guid.NewGuid();
            userDataModel.FirstName = "Иван";
            userDataModel.MiddleName = "Иванович";
            userDataModel.Surname = "Иванов";
            userDataModel.Version = 1;
            userDataModel.EmailAddress = $"user{stubNumber}@mail.ru";
            userDataModel.EmailAddressConfirmDate = DateTime.UtcNow;
            userDataModel.PhoneNumber = $"+7{stubNumber:D10}";
            userDataModel.PhoneNumberConfirmDate = DateTime.UtcNow;
            
            return userDataModel;
        }
    }
}
