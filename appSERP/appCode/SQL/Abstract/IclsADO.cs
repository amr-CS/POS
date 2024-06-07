using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.SQL.Abstract
{
    public interface IclsADO 
    {
        DataTable funFillDataTable(string pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null);
        object funExecuteScalar(String pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null);
        void funExecuteNonQuery(String pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null);
       DataTable funFillDataTableQuery(string queryText, List<SqlParameter> pLstParam = null);
        void funOpenConnection();
        void funCloseConnection();
    }
}
