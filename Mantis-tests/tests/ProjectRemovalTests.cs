using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Data;
using OpenQA.Selenium;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
    [Test]
        public void ProjectRemovalTest()
        {
            ProjectData newData = new ProjectData("test99");

            app.Menu.GoToManagementMenu();
            app.Menu.OpenProjectTab();
            if (!app.Project.IsElementPresent(By.CssSelector("[href*='manage_proj_edit_page']")))
            {
                app.Project.InitProjectCreation();
                app.Project.FillProjectForm(newData);
                app.Project.SubmitProjectCreation();
                app.Project.ReturnToProjectPage();
            }

            List<ProjectData> oldProjects = app.Project.GetProjectList();
            ProjectData toBeRemoved = oldProjects[0];

            app.Project.Remove(toBeRemoved);

            Assert.That(app.Project.GetProjectCount(), Is.EqualTo(oldProjects.Count - 1));

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.RemoveAt(0);
            Assert.That(newProjects, Is.EqualTo(oldProjects));

            foreach (ProjectData project in newProjects)
            {
                Assert.That(toBeRemoved.Id, Is.Not.EqualTo(project.Id));
            }
        }
    }
}