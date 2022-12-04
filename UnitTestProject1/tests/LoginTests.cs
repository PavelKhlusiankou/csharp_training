using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{

    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
    }
}