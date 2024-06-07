using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCustomerSupplier
    {
       

        string funCustomerSupplierGET(
        int? pCSId = null,
        string pCSCode = null,
        string pCSNameL1 = null,
        string pCSNameL2 = null,
        string pCSAddress = null,
        string pCSPhone1 = null,
        string pCSPhone2 = null,
        string pCSEmail = null,
        string pCSContactPerson = null,
        string pCSSalesPurchasePerson = null,
        string pCSTaxNumber = null,
        int? pAreaId = null,
        string pCSCreditLimit = null,
        int? pCSGroupId = null,
        int? pGracePeriod = null,
        int? pAccountId = null,
        int? pBranchId = null,
        bool? pCSIsCustomer = null,
        bool? pCSIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetCustomerSupplierReport();

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
