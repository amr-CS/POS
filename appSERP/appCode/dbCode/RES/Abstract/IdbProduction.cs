using appSERP.Models;
using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbProduction
    {
        string funProductionGET(
        int? pProductionId = null,
        string pProductionCode = null,
        int? pSubSeq = null,
        int? pTransId = null,
        DateTime? pTransDate = null,
        int? pTransStatus = null,
        int? pEmpId = null,
        int? pProdLine = null,
        bool? pIsPosted = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pProductionDtlId = null,
        int? pItemId = null,
        int? pSourceStore = null,
        int? pDestStore = null,
        int? pSellStore = null,
        int? pAddId = null,
        int? pQTY = null,
        int? pUnitId = null,
        int? pTagId = null,
        string pNOTES = null,
        int? pRemainderQty = null,
        string phNumbers = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? branchid = null,
        int? pQueryTypeId = null);

        DataTable funGetProductionOrderReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, bool? pIsActive = null);
        DataTable funGetProductionContentReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, bool? pIsActive = null);
        DataTable funGetProductionOutReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null);
        object AddQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? StoreId, DateTime? InvDate, int? UserId = null, int? BranchId = null);
        object RemoveQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? StoreId, DateTime? InvDate, int? UserId = null, int? BranchId = null);
        object ProductionBulk(ICollection<Production> ProductionDtl, int? ProductionId);


    }
}
