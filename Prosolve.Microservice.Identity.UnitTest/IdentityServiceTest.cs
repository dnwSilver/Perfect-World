using System;

using FluentAssertions;

using NUnit.Framework;

namespace Prosolve.MicroService.Identity.UnitTest
{
    /// <summary>
    ///     Набор тестов для объекта <see cref="IIdentityService" />.
    /// </summary>
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // Act
            var emailAddress = Create.EmailAddress("Kolosov@gmail.com").ConfirmedAt(DateTime.UtcNow).Please();
            var user = Create.User().WithContact(emailAddress).Please();
            var identityService = Create.IdentityService().Please();
            var searchParameters = Create.UserSearchParameters().WithId(user.Id).Please();

            // Arrange
            var searchResult = identityService.FindUserAsync(searchParameters);

            // Assert
            searchResult.Should().HaveCount(1, "Мы только знаем что в репозитории есть только один объект.");
        }
    }
}
