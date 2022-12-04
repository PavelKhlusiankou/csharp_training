using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CreateNewIssue(AccountData account, ProjectData project, IsuueData issueData)
        {
            Mantis.MantisConnectProtTypeClient client = new Mantis.MantisConnectProtTypeClient();
            Mantis.IsuueData issue = new Mantis.IsuueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
        public List<ProjectData> GetProjectList()
        {
            Mantis.MantisConnectProtTypeClient client = new Mantis.MantisConnectProtTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            client.mc_projects_get_user_accessible(project);
            return new List<ProjectData>();
        }

        public void CreateProject()
        {
            Mantis.MantisConnectProtTypeClient client = new Mantis.MantisConnectProtTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = project.ProjectName;
            client.mc_project_add(project);
        }
    }
}
