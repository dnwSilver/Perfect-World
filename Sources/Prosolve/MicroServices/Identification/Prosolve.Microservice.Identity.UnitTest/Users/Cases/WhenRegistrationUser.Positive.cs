using System;

using NUnit.Framework;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUser))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenRegistrationUserPositive
    {
        [Test]
        public void WhenRegistrationUser_WithEmailAddress_ResultShouldBeTrue()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void WhenRegistrationUser_WithPhoneNumber_ResultShouldBeTrue()
        {
            throw new NotImplementedException();
        }
    }
}
