using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{
    public struct Column
    {

      
        public string Name { get; set; }

        public Type TypeName { get; set; }

        public bool Primary { get; set; }

        public bool Identity { get; set; }
    }
}
