using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Data;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
    [Test]
        public void ProjectRemovalTest()
        {
            ProjectData project = new ProjectData()
            {
                ProjectName = "test99"
            };
            AccountData account = new AccountData()
            {
                Name = "Administrator",
                Password = "root"
            };

            app.Menu.GoToManagementMenu();
            app.Menu.OpenProjectTab();
            if (!app.Project.IsElementPresent(By.CssSelector("[href*='manage_proj_edit_page']")))
            {
                //app.Project.InitProjectCreation();
                //app.Project.FillProjectForm(project);
                //app.Project.SubmitProjectCreation();
                //app.Project.ReturnToProjectPage();
                app.API.CreateProject(account, project);
                app.Menu.OpenProjectTab();
            }
            //List<ProjectData> oldProjects = app.Project.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectList(account);
            ProjectData toBeRemoved = oldProjects[0];

            app.Project.Remove(toBeRemoved);

            Assert.That(app.Project.GetProjectCount(), Is.EqualTo(oldProjects.Count - 1));

            //List<ProjectData> newProjects = app.Project.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList(account);

            oldProjects.RemoveAt(0);

            Assert.That(newProjects, Is.EqualTo(oldProjects));

        }
    }
}