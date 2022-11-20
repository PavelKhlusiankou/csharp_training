using AutoItX3Lib;
using NUnit.Framework.Internal;

namespace addressbook_tests_autoit2
{
    public class HelperBase
    {
        public ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}