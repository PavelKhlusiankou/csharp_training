using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using LinqToDB.Mapping;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace Mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "name")]
        public string ProjectName { get; set; }
       
        [Column(Name = "id")]
        public string Id { get; set; }

        public ProjectData(string name)
        {
            ProjectName = name;
        }

        public ProjectData()
        {
        }
        public bool Equals(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ProjectName == other.ProjectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        public static List<ProjectData> GetAll()
        {
            using (Mantis_testsDB db = new Mantis_testsDB())
            {
                return (from p in db.Project select p).ToList();
            }
        }
    }
}
