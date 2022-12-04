using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "Administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "1"
            };
            IsuueData issue = new IsuueData()
            {
                Summary = "some text",
                Description = "some long text",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
