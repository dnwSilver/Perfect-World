using System;

using Prosolve.Services.Identification.Users.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для процесса <see cref="UserDataModel" />.
    /// </summary>
    internal class UserDataModelObjectGenerator : TestObjectGeneratorBase<UserDataModel>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override UserDataModel Allocate(int testObjectNumber)
        {
            //Нельзя задавать уникальные приватные идентификаторы, их выдаёт база данных.
            var userDataModel = new UserDataModel();
            userDataModel.PublicId = new Guid("DD7B81BA-97DA-429E-BF2D-6495175F778E");
            userDataModel.FirstName = "Иван";
            userDataModel.MiddleName = "Иванович";
            userDataModel.Surname = "Иванов";
            userDataModel.Version = 1;
            // userDataModel.EmailAddress = $"user{testObjectNumber}@mail.ru";
            // userDataModel.EmailAddressConfirmDate = DateTime.UtcNow;
            // userDataModel.PhoneNumber = $"+7{testObjectNumber:D10}";
            // userDataModel.PhoneNumberConfirmDate = DateTime.UtcNow;
            
            return userDataModel;
        }
    }
}
