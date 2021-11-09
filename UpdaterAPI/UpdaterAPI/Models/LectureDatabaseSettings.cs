using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpdaterAPI.Models
{
    public class LectureDatabaseSettings : ILectureDatabaseSettings
    {
        public string LectureCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILectureDatabaseSettings
    {
        string LectureCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
