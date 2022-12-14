using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group1 = new GroupData("test1");
            group1.Header = "test2";
            group1.Footer = "test3";

            GroupData newData = new GroupData("test11");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
                    {
                    app.Groups.InitGroupCreation();
                    app.Groups.FillGroupForm(group1);
                    app.Groups.SubmitGroupCreation();
                    app.Groups.ReturnToGroupsPage();
                    }


            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModifided = oldGroups[0];

            app.Groups.InitGroupModification2(toBeModifided);
            app.Groups.FillGroupForm(newData);
            app.Groups.SubmitGroupModification();
            app.Groups.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModifided.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
