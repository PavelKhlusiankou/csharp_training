using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";

            GroupData newData = new GroupData("test11");
            newData.Header = null;
            newData.Footer = null;

            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(0, group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.InitGroupModification();
            app.Groups.FillGroupForm(newData);
            app.Groups.SubmitGroupModification();
            app.Groups.ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
