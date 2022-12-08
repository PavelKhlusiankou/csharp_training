using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper Create(ProjectData projectname)
        {
            manager.Menu.GoToManagementMenu();
            manager.Menu.OpenProjectTab();
            InitProjectCreation();
            FillProjectForm(projectname);
            SubmitProjectCreation();
            ReturnToProjectPage();
            return this;
        }


        public ProjectManagementHelper ReturnToProjectPage()
        {
            driver.FindElement(By.LinkText("Proceed")).Click();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            projectCache = null;
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.ProjectName);
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        private List<ProjectData> projectCache = null;

        //public List<ProjectData> GetProjectList()
       // {
         //   if (projectCache == null)
          //  {
           //     projectCache = new List<ProjectData>();
            //    manager.Menu.GoToManagementMenu();
             //   manager.Menu.OpenProjectTab();
              //  ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[href*='manage_proj_edit_page']"));
              //  foreach (IWebElement element in elements)
               // {
               //     projectCache.Add(new ProjectData(element.Text)
               //     {
               //         Id = element.FindElement(By.CssSelector("[href*='manage_proj_edit_page']")).GetAttribute("value")
               //     });
               // }
            //}
           // return new List<ProjectData>(projectCache);
       // }

        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("[href*='manage_proj_edit_page']")).Count;
        }
        public ProjectManagementHelper Remove(ProjectData project)
        {
            OpenProject(project.Id);
            DeleteProject();
            SubmitProjectDeleting();
            projectCache = null;
            return this;
        }

        public ProjectManagementHelper SubmitProjectDeleting()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper DeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper OpenProject(String id)
        {
            driver.FindElement(By.XPath("//a[contains(@href, 'manage_proj_edit_page.php?project_id=" + (id) + "')]")).Click();
            return this;
        }

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Menu.GoToManagementMenu();
                manager.Menu.OpenProjectTab();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[href*='manage_proj_edit_page']"));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.Text));
                }
            }
            return new List<ProjectData>(projectCache);
        }



    }
}
