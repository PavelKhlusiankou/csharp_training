using NUnit.Framework.Internal;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        public ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}