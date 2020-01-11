using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для процесса <see cref="IUserBuilder"/>.
    /// </summary>
    internal class UserBuilderStubGenerator: TestObjectGeneratorBase<IUserBuilder>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber"> Порядковый номер создаваемого объекта. </param>
        /// <returns> Созданный объект, размещённый в куче. </returns>
        protected override IUserBuilder Allocate(int testObjectNumber)
        {
            return new UserBuilder
            {
                Identifier = Prepare.Identifier<IUserAggregate>().PorFavor,
                FullName = Prepare.FullName.PorFavor,
                ContactEmailAddress = Prepare.EmailAddress.PorFavor,
                ContactPhoneNumber = Prepare.PhoneNumber.PorFavor,
                Version = 1
            };
        }
    }
}
