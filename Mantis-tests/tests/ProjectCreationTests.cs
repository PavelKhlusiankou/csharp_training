using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Data;
using System.Security.Cryptography;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
         [Test]
        public void ProjectCreationTest()
        {
            ProjectData projectname = new ProjectData("test 1");


            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Create(projectname);

            Assert.That(app.Project.GetProjectCount(), Is.EqualTo(oldProjects.Count +1));

            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.Add(projectname);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
