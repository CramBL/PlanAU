using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Models
{
    public class Course : ICourse
    {
        public string Name { get; set; }
        public Course(string name)
        {
            Name = name;
        }
    }

    public interface ICourse
    {
    }
}
