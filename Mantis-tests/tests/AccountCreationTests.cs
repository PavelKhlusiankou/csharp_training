using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("c:/xampp/htdocs/mantisbt-2.25.4/config/config_inc.php");
            using (Stream localFile = File.Open("c:/xampp/htdocs/mantisbt-2.25.4/config/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("c:/xampp/htdocs/mantisbt-2.25.4/config/config_inc.php", localFile);
            }

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhosts.localdomain"
            };

            app.Registration.Register(account);

        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("c:/xampp/htdocs/mantisbt-2.25.4/config/config_inc.php");
        }
    }


}
