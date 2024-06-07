using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserSecurityTransactionType
    {
        string funUserSecurityTransactionTypeGET(
        string pUserSecurityTransactionTypeId = null,
        string pUserSecurityTransactionTypeNameL1 = null,
        string pUserSecurityTransactionTypeNameL2 = null,
        string pUserSecurityTransactionTypeNameL3 = null,
        string pUserSecurityTransactionTypeNameL4 = null,
        string pUserSecurityTransactionTypeNameL5 = null,
        string pUserSecurityTransactionTypeNameL6 = null,
        string pUserSecurityTransactionTypeNameL7 = null,
        string pUserSecurityTransactionTypeNameL8 = null,
        string pUserSecurityTransactionTypeNameL9 = null,
        string pUserSecurityTransactionTypeNameL10 = null,
        bool? pUserSecurityTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetUserSecurityTransactionTypeReport();


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
