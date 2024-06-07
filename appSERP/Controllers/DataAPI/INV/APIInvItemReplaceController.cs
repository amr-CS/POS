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
    public class APIInvItemReplaceController : ApiController
    {
        private IdbInvItemReplace _dbInvItemReplace;
        public APIInvItemReplaceController(IdbInvItemReplace dbInvItemReplace)
        {
            _dbInvItemReplace = dbInvItemReplace;
        }

        [HttpGet]
        public string InvItemReplaceGET(
      int? pInvItemReplaceId = null,
     string pInvItemReplaceCode = null,
    int? pItemId = null,
   int? pReplaceItemId = null,
    string pNotes = null,
    bool? pInvItemReplaceIsActive = true,
    bool? pIsDeleted = false,
    int? pQueryTypeId = clsQueryType.qSelect
)
        {
            // Get Data 
            string vData = _dbInvItemReplace.funInvItemReplaceGET(
            pInvItemReplaceId: pInvItemReplaceId,
            pInvItemReplaceCode: pInvItemReplaceCode,
            pItemId: pItemId,
            pReplaceItemId: pReplaceItemId,
            pNotes: pNotes,
            pInvItemReplaceIsActive: pInvItemReplaceIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
