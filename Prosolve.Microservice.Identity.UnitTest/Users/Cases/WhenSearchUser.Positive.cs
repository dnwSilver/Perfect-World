using FluentAssertions;

using NUnit.Framework;

using Prosolve.MicroService.Identity.Entities.Users;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Cases
{
    /// <summary>
    ///     Набор тестов для объекта <see cref="IIdentityService" />.
    ///     Тип тестов предназначенный для проверки бизнес логики.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class WhenSearchUser
    {
        [Test]
        public void WhenSearchUser_ShouldHaveSomeCount()
        {
            // Act:
            var userId = Create.Identifier<IUser>().PrivateId(1).Please();
            var searchParameters = Create.UserSearchParameters().With(userId).Please();
            var user = Create.User().With(userId).Please();
            var userRepository = Create.UserRepository().With(user).Please();
            var identityService = new IdentityService(userRepository);

            // Arrange:
            var searchResult = identityService.FindUser(searchParameters).Value;

            // Assert:
            searchResult.Should().HaveCountGreaterThan(0, " repository have some users");
        }
    }
}
