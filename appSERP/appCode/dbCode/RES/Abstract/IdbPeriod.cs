using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbPeriod
    {
        DataTable funPeriodGET(
          int? pPeriodId = null,
          DateTime? pFromDate = null,
         DateTime? pToDate = null,
        bool? pIsPosted = null,
       bool? pIsPostedStore = null,
       bool? pIsDeleted = null,
      int? pLanguageId = null,
      int? pCreatedBy = null,
      int? pQueryTypeId = clsQueryType.qSelect);

        string PostStorePeriodGET(
        DateTime? DateFrom = null,
       DateTime? DateTo = null);
        string PostInvoice(int? InvId = null);
    }
}
