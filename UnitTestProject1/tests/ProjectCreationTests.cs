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
            ProjectData project = new ProjectData("test 1");

            // List<ProjectData> oldProjects = app.Project.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectList();

            app.Project.Create(project);

            Assert.That(app.Project.GetProjectCount(), Is.EqualTo(oldProjects.Count +1));

            //List<ProjectData> newProjects = app.Project.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.That(newProjects, Is.EqualTo(oldProjects));
            
            app.Project.Remove(project);

        }
    }
}
