using NUnit.Framework;
using System;
using System.Collections.Concurrent;


namespace addressbook_tests_autoit2
{
    [TestFixture]   
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count());
        }
    }
}