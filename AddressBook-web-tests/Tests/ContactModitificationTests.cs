﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class ContactModitificationTests : AuthTestBase
    {
        [Test]
        public void COntactModificationTest()
        {
            ContactData newData = new ContactData("test11");
            newData.LastName = "test12";
            ContactData contact1 = new ContactData("test1");
            contact1.LastName = "test2";

            app.Contact.IsContactsExist(contact1);
            app.Contact.SelectContact();

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contact.InitContactModification(0);
            app.Contact.FillContactForm(newData);
            app.Contact.SubmitContactModification();
            app.Navigator.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }
    }
}
