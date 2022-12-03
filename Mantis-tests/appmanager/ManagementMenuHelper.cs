using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ManagementMenuHelper GoToManagementMenu()
        {
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='Manage']/parent::*")).Click();
            return this;
        }
        public ManagementMenuHelper OpenProjectTab()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
            return this;
        }
    }
}
