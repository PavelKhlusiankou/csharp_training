using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Data;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
         [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData("test 1");
            AccountData account = new AccountData()
            {
                Name = "Administrator",
                Password = "root"
            };
             //List<ProjectData> oldProjects = app.Project.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.Project.Create(project);

            Assert.That(app.Project.GetProjectCount(), Is.EqualTo(oldProjects.Count + 1));

            //List<ProjectData> newProjects = app.Project.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.That(newProjects, Is.EqualTo(oldProjects));
            
            app.Project.Remove(project);

        }
    }
}
