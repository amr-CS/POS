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
    public class APIInvItemBarcodeController : ApiController
    {
        private IdbInvItemBarcode _dbInvItemBarcode;
        public APIInvItemBarcodeController(IdbInvItemBarcode dbInvItemBarcode) {
            _dbInvItemBarcode = dbInvItemBarcode;
        }

        [HttpGet]
        public string InvItemBarcodeGET(
  int? pInvItemBarcodeId = null,
 string pInvItemBarcodeCode = null,
int? pItemId = null,
int? pUnitId = null,
string pItemBarCode = null,
bool? pInvItemBarcodeIsActive = true,
bool? pIsDeleted = false,
int? pQueryTypeId = clsQueryType.qSelect
)
        {
            // Get Data 
            string vData = _dbInvItemBarcode.funInvItemBarcodeGET(
            pInvItemBarcodeId: pInvItemBarcodeId,
            pInvItemBarcodeCode: pInvItemBarcodeCode,
            pItemId: pItemId,
            pUnitId: pUnitId,
            pItemBarCode: pItemBarCode,
            pInvItemBarcodeIsActive: pInvItemBarcodeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
