using System;
using System.Collections.Generic;
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
            return this;
        }

        public ContactHelper ConfirmationOfDeleting()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(ContactData contact)
        {
            if (!IsElementPresent(By.ClassName("entry")))
            {
                InitContactCreation();
                FillContactForm(contact);
                SubmitContactCreation();
                manager.Navigator.ReturnToHomePage();
            }
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.ClassName("entry"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }
    }
}