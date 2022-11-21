using NUnit.Framework;
using System;
using System.Collections.Concurrent;


namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTestss : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            newGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

