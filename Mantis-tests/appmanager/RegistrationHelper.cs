using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegistrationForm(AccountData account)
        {
            throw new NotImplementedException();
        }

        private void OpenMainPage()
        {
            throw new NotImplementedException();
        }
    }
}
