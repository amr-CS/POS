using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvSubItemController : ApiController
    {
        private IdbInvSubItem _dbInvSubItem;
        public APIInvSubItemController(IdbInvSubItem dbInvSubItem) {
            _dbInvSubItem = dbInvSubItem;
        }

        [HttpGet]
        public string InvSubItemGET(
     int? pSubItemId = null,
        string pSubItemCode = null,
       string pSubItemNameL1 = null,
      string pSubItemNameL2 = null,
      int? pPiecesCount = null,
       int? pItemId = null,
        string pNotes = null,
        bool? pSubItemIsActive = null,
    bool? pIsDeleted = false,
    int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbInvSubItem.funInvSubItemGET(
           pSubItemId : pSubItemId,
         pSubItemCode : pSubItemCode,
        pSubItemNameL1 : pSubItemNameL1,
       pSubItemNameL2 : pSubItemNameL2,
       pPiecesCount : pPiecesCount,
         pItemId : pItemId,
         pNotes: pNotes,
          pSubItemIsActive : pSubItemIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
