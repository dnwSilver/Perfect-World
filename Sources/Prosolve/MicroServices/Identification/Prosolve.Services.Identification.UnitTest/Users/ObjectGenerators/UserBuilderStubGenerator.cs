using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для процесса <see cref="IUserBuilder" />.
    /// </summary>
    internal class UserBuilderStubGenerator : TestObjectGeneratorBase<IUserBuilder>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IUserBuilder AllocateStub(int stubNumber)
        {
            var userBuilder = new UserBuilder()
                             .SetFullName(Create.FullName.PorFavor)
                             .SetContactEmailAddress(Create.EmailAddress.PorFavor)
                             .SetContactPhoneNumber(Create.PhoneNumber.PorFavor)
                             .SetIdentifier(Create.Identifier<IUserAggregate>().PorFavor)
                             .SetVersion(1) as IUserBuilder;

            return userBuilder;
        }
    }
}
