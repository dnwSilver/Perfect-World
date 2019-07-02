using System;

using FluentAssertions;

using NUnit.Framework;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    public partial class WhenRegistrationUser
    {
        [Test]
        public void WhenRegistrationUser_WithExistsEmailAddress_ResultShouldBeFailure()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void WhenRegistrationUser_WithExistsPhoneNumber_ResultShouldBeFailure()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void WhenRegistrationUser_WithoutContactInformation_ResultShouldBeFailure()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void WhenRegistrationUser_WithoutFullName_ResultShouldBeFailure()
        {
            throw new NotImplementedException();
        }
    }
}
