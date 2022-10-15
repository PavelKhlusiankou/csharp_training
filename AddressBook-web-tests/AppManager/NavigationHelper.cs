﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        public string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}