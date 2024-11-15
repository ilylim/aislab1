using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class StudentEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Speciality { get; set; }
        public int Id { get; set; }
    }
}
