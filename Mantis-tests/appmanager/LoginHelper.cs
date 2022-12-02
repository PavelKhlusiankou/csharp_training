using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();            
            }
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggerUserName() == account.Name;
        }

        private string GetLoggerUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Account'])[1]/preceding::span[1]")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//a[contains(text(),'administrator')]"));
        }
    }
}
