using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Model
{
    public class PagedResultModel<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<T> results { get; set; }
    }
}
