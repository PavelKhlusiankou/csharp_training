using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;

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

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(element.Text)
                    {
                        FirstName = cells[2].Text,
                        LastName = cells[1].Text
                });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
        }



        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
           
            return new ContactData(firstName)
            {
                LastName = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

           return new ContactData(firstName)
            {
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text =  driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        internal ContactData GetContactInformationFromContactDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetails();
            string fullData = driver.FindElement(By.XPath("//div[@id='content']")).Text.Trim();

            return new ContactData(fullData);

        }

        public ContactHelper OpenContactDetails()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact2(contact.Id);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContact2(String id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }
        public ContactHelper InitContactModification2(ContactData contact, String id)
        {
            SelectContact2(contact.Id);
            driver.FindElement(By.Id(id))
                  .FindElement(By.TagName("a")).Click();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver,TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void RemoveContactFromGroup( GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Name);
            SelectContact();
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFilter(string group)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(group);
        }

        internal void SearchingContactsWithoutGroups(ContactData contact1)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilterNone();
            IsContactsExist(contact1);
        }
        public void SelectGroupFilterNone()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");
        }

        internal void SearchingContactsInGroups(GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Name);
            IsContactsExistInGroups( group);
        }

        private ContactHelper IsContactsExistInGroups( GroupData group)
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                SelectGroupFilterNone();
                SelectContact();
                SelectGroupToAdd(group.Name);
                CommitAddingContactToGroup();

            }
            return this;
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
