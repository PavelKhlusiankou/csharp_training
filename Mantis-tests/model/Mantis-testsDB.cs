using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mantis_tests
{
    public class Mantis_testsDB : LinqToDB.Data.DataConnection
    {
        public Mantis_testsDB() : base("mantis_project_table") { }

        public ITable<ProjectData> Project { get { return this.GetTable<ProjectData>(); } }
    }
}

