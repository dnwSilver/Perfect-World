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
            // Act
            var identityService = Create.IdentityService().Please();
            var userId = Create.Identifier<IUser>().With(1).Please();
            var searchParameters = Create.UserSearchParameters().With(userId).Please();

            // Arrange
            var searchResult = identityService.FindUserAsync(searchParameters).Value;

            // Assert
            searchResult.Should().HaveCountGreaterThan(0, " repository have some users");
        }
    }
}
