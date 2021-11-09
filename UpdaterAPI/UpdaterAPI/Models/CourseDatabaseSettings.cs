using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpdaterAPI.Models
{
    public class CourseDatabaseSettings : ICourseDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICourseDatabaseSettings
    {
        string CourseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
