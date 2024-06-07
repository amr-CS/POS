using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbResOrderLocation
    {
       string funResOrderLocationGET(
       int? pOrderLocId = null,
       int? pOrderId = null,
       int? pCUST_LOC_SEQ = null,
       string pADDRESS = null,
       string pNOTES = null,
       int? pCOMP_ID = null,
       bool? pIsDeleted = null,
       int? pCreatedBy = null,
       DateTime? pCreatedOn = null,
       int? pLastUpdatedBy = null,
       DateTime? pLastUpdatedOn = null,
       int? pLanguageId = null,
       int? pQueryTypeId = clsQueryType.qSelect);
    }
}
