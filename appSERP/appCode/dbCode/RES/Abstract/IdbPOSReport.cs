using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbPOSReport
    {
        DataTable funPOSReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null,
        int? BranchId = null
        );

        DataTable SheepReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null
      );

        DataTable funPOSDTLReportGET(
         DateTime? pDateFrom = null,
         DateTime? pDateTo = null,
         DateTime? pTodayDate = null,
             int? pCashierId = null,
             int? BranchId = null

         );

        DataTable funPOSGroupingReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null,
             int? BranchId = null
      );

        DataTable funDriverReportGET(
            DateTime? pDateFrom = null,
            DateTime? pDateTo = null,
            DateTime? pTodayDate = null,
            int? InvTypeId = null,
             int? BranchId = null
            );

        DataTable funDriverCashReportGET(
          DateTime? pDateFrom = null,
          DateTime? pDateTo = null,
          DateTime? pTodayDate = null,
          int? DeliveryId = null,
          int? CashierId = null);

        DataTable funPOSGroupingCasherReportGET(
          DateTime? pDateFrom = null,
          DateTime? pDateTo = null,
          DateTime? pTodayDate = null,
          int? pCashierId = null
      );

        DataTable funPOSDTLCasherReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
           int? pCashierId = null
       );

        DataTable funPOSInsReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null
   );


        DataTable funPOSInsReturnReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null
);

        DataTable funPOSDeletedReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null,
        int? pCashierId = null,
        int? CustomerId = null,
        bool? IsCancel = null,
        int? InvType = null

            );

        DataTable funPOSReceiptVoucherReportGET(
        DateTime? pDateFrom = null,
        DateTime? pDateTo = null,
        DateTime? pTodayDate = null
        );

    }
}
