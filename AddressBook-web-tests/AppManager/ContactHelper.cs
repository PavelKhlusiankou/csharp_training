﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ConfirmationOfDeleting()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                IList<IWebElement> cells = driver.FindElements(By.TagName("td"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
        }

        public ContactHelper IsContactsExist(ContactData contact)
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                InitContactCreation();
                FillContactForm(contact);
                SubmitContactCreation();
                manager.Navigator.ReturnToHomePage();
            }
            return this;
        }
    }
}
