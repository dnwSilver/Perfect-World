using System;

using NUnit.Framework;

using Prosolve.MicroService.Identification.Entities.Users;

using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUser))]
    [Category(Constant.Negative)]
    [Parallelizable(ParallelScope.All)]
    public class WhenRegistrationUserNegative
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
