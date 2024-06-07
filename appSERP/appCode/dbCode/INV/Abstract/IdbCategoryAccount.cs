using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbCategoryAccount
    {
        string funCategoryAccountGET(

        int? pCategoryAccountId = null,
        string pCategoryAccountCode = null,
        string pCategoryAccountNameL1 = null,
        string pCategoryAccountNameL2 = null,
        int? pCurrencyId = null,
        int? pAccountId = null,
        int? pSalesAccountId = null,
        int? pReturnSalesAccountId = null,
        int? pDiscountReceivedId = null,
        int? pDiscountAllowedId = null,
        int? pTaxAccountId = null,
        int? pGroupAccountId = null,
        int? pReturnPurchasesAccountId = null,
        int? pSalesCostAccountId = null,
        int? pProductTypeId = null,
        bool? pCategoryAccountIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
