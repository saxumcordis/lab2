using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_2
{
    public abstract class Entity
    {
        public int id { get; set; }
        public abstract Entity fromRepository(object[] arr);
    }
}
