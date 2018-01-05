using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{

    public interface ISQLBulider {

        string GetInsertText();

    }
   
}
