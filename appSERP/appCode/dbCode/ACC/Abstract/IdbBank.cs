using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbBank
    {
        string funBankGET(
            int? pBankId = null,
            int? pBankParentId = null,
            string pBankCode = null,
            string pBankNameL1 = null,
            string pBankNameL2 = null,
            string pBankAccountNameL1 = null,
            string pBankAccountNameL2 = null,
            bool? pBankAccountIsActive = null,
            int? pBankTypeId = null,
            bool? pBankIsActive = null,
            bool? pIsDeleted = false,
            int? pBankAccountId = null,
            string pAccountId = null,
            bool? pIsAccountDetail = null,
            int? pQueryTypeId = null);

        DataTable funBankReportGET(bool? pIsActive = null);

         string vSQLResult { get; set; }
         int vSQLResultTypeId { get; set; }
    }
}
